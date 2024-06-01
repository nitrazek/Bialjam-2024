using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static StoryStages StoryStage = StoryStages.DesktopWelcome;
    public static bool UiBlocked = false;

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
    Round1,
    Round2,
    DesktopAnomaly,
    Round3,
    RightsAnomaly,
    Round4,
    RightsAnomalyForced,
    Round5,
    Round6,
    TransferToBigScreen,
    Round7,
    LastDesktopAnomaly,
    Round8,
    Round9,
}
