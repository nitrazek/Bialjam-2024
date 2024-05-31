using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashGameController : MonoBehaviour
{
    void Update()
    {
        if(GameState.StoryStage == StoryStages.DesktopAnomaly)
        {
            SceneManager.LoadScene("DesktopScene");
        }
    }
}
