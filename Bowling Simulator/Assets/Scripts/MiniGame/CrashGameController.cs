using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashGameController : MonoBehaviour
{
    public AudioSource audio;
    public Camera camera;
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

        camera.enabled = false;

        // Wait until the crash sound finishes playing
        yield return new WaitWhile(() => audio.isPlaying);

        camera.enabled = true;

        // Load the new scene
        SceneManager.LoadScene("DesktopScene");
        isCoroutineRunning = false;
    }
}
