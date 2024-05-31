using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static StoryStages StoryStage = StoryStages.DesktopWelcome;

    public static StoryStages NextStage()
    {
        StoryStage = (StoryStages)(((int)StoryStage + 1) % System.Enum.GetValues(typeof(StoryStages)).Length);
        return StoryStage;
    }
}

public enum StoryStages
{
    DesktopWelcome,
    ChatWindowOpen,
    DesktopInstalledGame,
    GameStarted,
    Round1,
    Round2,
    DesktopAnomaly,
    Round3,
}
