using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSwitcher : MonoBehaviour
{
    private StoryStages lastStoryStage;

    [SerializeField] GameObject pins;
    [SerializeField] GameObject dawgPins;

    void Update()
    {
        StoryStages currentStage = GameState.StoryStage;
        if (currentStage == StoryStages.Round5 && currentStage != lastStoryStage)
        {
            lastStoryStage = GameState.StoryStage;
            pins.SetActive(false);
            dawgPins.SetActive(true);
        }
    }
}
