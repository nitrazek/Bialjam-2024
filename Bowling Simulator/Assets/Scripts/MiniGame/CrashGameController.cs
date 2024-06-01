using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashGameController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip crash_sound;
    public AudioClip fighting_sound;
    public AudioClip punch_sound;
    private bool isCoroutineRunning = false;

    [SerializeField] private BallCamera ballCamera;

    void Update()
    {
        if(!isCoroutineRunning &&
          (GameState.StoryStage == StoryStages.DesktopAnomaly
          || GameState.StoryStage == StoryStages.RightsAnomaly
          || GameState.StoryStage == StoryStages.RightsAnomalyForced
          || GameState.StoryStage == StoryStages.TransferToBigScreen
          || GameState.StoryStage == StoryStages.LastDesktopAnomaly))
        {
            StartCoroutine(PlayCrashSoundAndLoadScene());
        }
        else if(!isCoroutineRunning && GameState.StoryStage == StoryStages.FinalScene)
        {
            StartCoroutine(PlayFightingSoundAndLoadScene());
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
        ballCamera.TurnOffTargetTexture();

        // Load the new scene
        SceneManager.LoadScene("DesktopScene");
        isCoroutineRunning = false;
    }

    IEnumerator PlayFightingSoundAndLoadScene()
    {
        isCoroutineRunning = true;
        
        audioSource.Stop();
        ballCamera.OnFreeze();
        yield return new WaitForSeconds(1f);

        audioSource.PlayOneShot(fighting_sound);
        // Wait until the crash sound finishes playing
        yield return new WaitWhile(() => audioSource.isPlaying);
        audioSource.PlayOneShot(punch_sound);
        yield return new WaitWhile(() => audioSource.isPlaying);

        ballCamera.OnStopFreeze();
        ballCamera.TurnOffTargetTexture();

        // Load the new scene
        SceneManager.LoadScene("DesktopScene");
        isCoroutineRunning = false;
    }
}
