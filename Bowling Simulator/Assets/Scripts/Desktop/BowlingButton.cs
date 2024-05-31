using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BowlingButton : MoveButton
{
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
           || GameState.StoryStage == StoryStages.RightsAnomaly
           || GameState.StoryStage == StoryStages.RightsAnomalyForced)
        {
            SceneManager.LoadScene("BowlingScene");
            GameState.NextStage();
            return;
        }
    }
}
