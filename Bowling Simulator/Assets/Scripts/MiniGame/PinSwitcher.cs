using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSwitcher : MonoBehaviour
{
    [SerializeField] GameObject pins;
    [SerializeField] GameObject dawgPins;

    void Update()
    {
        if (GameState.StoryStage >= StoryStages.Round5)
        {
            pins.SetActive(false);
            dawgPins.SetActive(true);
            return;
        }
        pins.SetActive(true);
        dawgPins.SetActive(false);
    }
}
