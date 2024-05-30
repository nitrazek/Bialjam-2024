using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinResetter : MonoBehaviour
{
    public void Reset()
    {
        PinController[] pins = GetComponentsInChildren<PinController>();
        foreach (PinController pin in pins)
        {
            pin.Reset();
        }
    }
}
