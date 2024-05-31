using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public Image chatWindow;
    public Image chatBubble_1;
    public Image chatBubble_2;
    public Image chatBubble_3;
    public AudioSource windowOpenSound;
    public AudioSource windowCloseSound;
    public AudioSource messageSound;

    void Start()
    {
        StartCoroutine(PlayStory());
    }

    private IEnumerator PlayStory()
    {
        yield return new WaitForSeconds(7f);
        GameState.NextStage();
        //windowOpenSound.Play();
        chatWindow.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);
        //messageSound.Play();
        chatBubble_1.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);
        //messageSound.Play();
        chatBubble_2.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);
        //messageSound.Play();
        chatBubble_3.gameObject.SetActive(true);
    }
}
