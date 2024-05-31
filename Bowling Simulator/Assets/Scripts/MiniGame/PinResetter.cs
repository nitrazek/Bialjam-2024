using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinResetter : MonoBehaviour
{
    private GameObject currentPins;
    private StoryStages lastStoryStage;

    [SerializeField] private GameObject pins;
    [SerializeField] private GameObject dawgPins;

    void Start()
    {
        currentPins = pins;
    }

    void Update()
    {
        StoryStages currentStage = GameState.StoryStage;
        if (currentStage == StoryStages.Round5 && lastStoryStage != currentStage)
        {
            lastStoryStage = currentStage;
            currentPins = dawgPins;
        }
    }

    public void Reset(short currentRoundHalf)
    {
        PinController[] pins = currentPins.GetComponentsInChildren<PinController>(true);
        foreach (PinController pin in pins)
        {
            if (pin.IsKnockedOver() && currentRoundHalf == 1)
            {
                pin.SetEnable(false);
            }
            else
            {
                pin.SetEnable(true);
                pin.Reset();
            }
        }
    }
}
