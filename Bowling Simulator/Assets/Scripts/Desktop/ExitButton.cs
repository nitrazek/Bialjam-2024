using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    public RawImage sceneFrame;
    public void ExitGame()
    {
        if (sceneFrame.gameObject.activeSelf)
            return;

        Application.Quit();
    }
}
