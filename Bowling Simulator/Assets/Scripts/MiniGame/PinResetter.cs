using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinResetter : MonoBehaviour
{
    public void Reset(short currentRoundHalf)
    {
        PinController[] pins = GetComponentsInChildren<PinController>(true);
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
