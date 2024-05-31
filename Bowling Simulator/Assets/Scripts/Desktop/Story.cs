using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public Image chatWindow;
    public Image chatBubble_1;
    public AudioSource messageSound;

    void Start()
    {
        StartCoroutine(PlayStory());
    }

    IEnumerator PlayStory()
    {
        yield return new WaitForSeconds(7f);
        GameState.NextStage();
        messageSound.Play();
        chatWindow.enabled = true;

        yield return new WaitForSeconds(1f);
        messageSound.Play();
        chatBubble_1.enabled = true;
    }
}
