using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashGameController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip crash_sound;
    private bool isCoroutineRunning = false;

    [SerializeField] private BallCamera ballCamera;

    void Update()
    {
        if(!isCoroutineRunning &&
          (GameState.StoryStage == StoryStages.DesktopAnomaly
          || GameState.StoryStage == StoryStages.RightsAnomaly
          || GameState.StoryStage == StoryStages.RightsAnomalyForced))
        {
            StartCoroutine(PlayCrashSoundAndLoadScene());
        }
    }

    IEnumerator PlayCrashSoundAndLoadScene()
    {
        isCoroutineRunning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash_sound);

        ballCamera.OnFreeze();

        // Wait until the crash sound finishes playing
        yield return new WaitWhile(() => audioSource.isPlaying);

        ballCamera.OnStopFreeze();

        // Load the new scene
        SceneManager.LoadScene("DesktopScene");
        isCoroutineRunning = false;
    }
}
