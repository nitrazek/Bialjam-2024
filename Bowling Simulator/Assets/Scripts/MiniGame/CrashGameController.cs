using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashGameController : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip crash_sound;
    private bool isCoroutineRunning = false;

    void Update()
    {
        if(GameState.StoryStage == StoryStages.DesktopAnomaly && !isCoroutineRunning)
        {
            StartCoroutine(PlayCrashSoundAndLoadScene());
        }
    }

    IEnumerator PlayCrashSoundAndLoadScene()
    {
        isCoroutineRunning = true;
        audio.Stop();
        audio.PlayOneShot(crash_sound);

        // Wait until the crash sound finishes playing
        yield return new WaitWhile(() => audio.isPlaying);

        // Load the new scene
        SceneManager.LoadScene("DesktopScene");
        isCoroutineRunning = false;
    }
}
