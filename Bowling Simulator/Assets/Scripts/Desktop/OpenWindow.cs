using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWindow : MonoBehaviour
{
    public void Window_Open()
    {
        if (GameState.UiBlocked)
            return;

        gameObject.SetActive(true);
    }
}
