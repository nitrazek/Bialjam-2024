using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BowlingButton : MoveButton
{
    public void Button_Click()
    {
        if(IsDragging)
        {
            IsDragging = false;
            return;
        }
        
        if(GameState.StoryStage == StoryStages.DesktopInstalledGame)
        {
            SceneManager.LoadScene("BowlingScene");
            GameState.NextStage();
            return;
        }
    }
}
