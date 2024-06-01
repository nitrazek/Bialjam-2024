using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameButton : MoveButton
{
    public RawImage sceneFrame;
    public void Button_Click()
    {
        if (GameState.UiBlocked) return;
        if (IsDragging)
        {
            IsDragging = false;
            return;
        }
        
        if(GameState.StoryStage == StoryStages.DesktopInstalledGame
           || GameState.StoryStage == StoryStages.DesktopAnomaly
           || GameState.StoryStage == StoryStages.RightsAnomaly)
        {
            SceneManager.LoadScene("BowlingScene");
            GameState.NextStage();
            return;
        } else if(GameState.StoryStage == StoryStages.RightsAnomalyForced || GameState.StoryStage == StoryStages.LastDesktopAnomaly)
        {
            sceneFrame.gameObject.SetActive(true);
            SceneManager.LoadScene("BowlingScene", LoadSceneMode.Additive);
            GameState.NextStage();
            return;
        }
    }
}
