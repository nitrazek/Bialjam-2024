using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public Button gameButton;
    public Image chatWindow;
    public Image chatBubble_1;
    public Image chatBubble_2;
    public Image chatBubble_3;
    public float pulseScaleMultiplier = 1.1f;
    public float pulseAnimationDuration = 0.5f;
    public float downloadAnimationDuration = 0.5f;
    public AudioClip windowOpenClip;
    public AudioClip windowCloseClip;
    public AudioClip messageClip;
    private AudioSource windowOpenSound;
    private AudioSource windowCloseSound;
    private AudioSource messageSound;

    void Start()
    {
        windowOpenSound = gameObject.AddComponent<AudioSource>();
        windowOpenSound.clip = windowOpenClip;
        windowCloseSound = gameObject.AddComponent<AudioSource>();
        windowCloseSound.clip = windowCloseClip;
        messageSound = gameObject.AddComponent<AudioSource>();
        messageSound.clip = messageClip;
        StartCoroutine(PlayStory());
    }

    private IEnumerator PlayStory()
    {
        yield return new WaitForSeconds(7f);
        GameState.NextStage();
        windowOpenSound.Play();
        chatWindow.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);
        messageSound.Play();
        chatBubble_1.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);
        messageSound.Play();
        chatBubble_2.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);
        messageSound.Play();
        chatBubble_3.gameObject.SetActive(true);
    }

    public void DownloadGame()
    {
        StartCoroutine(SimulateDownloading());
    }

    private IEnumerator SimulateDownloading()
    {
        Image downloadImage = chatBubble_3.transform.GetChild(1).GetComponent<Image>();
        Debug.Log(downloadImage);
        downloadImage.gameObject.SetActive(true);
        for (int i = 0; i < 2; i++)
        {
            yield return StartCoroutine(FadeImage(downloadImage, 0f, 1f, pulseAnimationDuration));
            yield return StartCoroutine(FadeImage(downloadImage, 1f, 0f, pulseAnimationDuration));
        }
        yield return StartCoroutine(FadeImage(downloadImage, 0f, 1f, pulseAnimationDuration));
        yield return new WaitForSeconds(1f);
        downloadImage.gameObject.SetActive(false);
        chatBubble_3.gameObject.SetActive(false);
        chatBubble_2.gameObject.SetActive(false);
        chatBubble_1.gameObject.SetActive(false);
        chatWindow.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        GameState.NextStage();
        yield return StartCoroutine(PulseButton());
    }

    private IEnumerator FadeImage(Image image, float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;
        Color color = image.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            image.color = color;
            yield return null;
        }

        color.a = endAlpha;
        image.color = color;
    }

    private IEnumerator PulseButton()
    {
        gameButton.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Vector3 gameButtonScale = gameButton.transform.localScale;
        float elapsed = 0f;
        while (elapsed < pulseAnimationDuration)
        {
            gameButton.transform.localScale = Vector3.Lerp(gameButtonScale, gameButtonScale * pulseScaleMultiplier, elapsed / pulseAnimationDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        gameButton.transform.localScale = gameButtonScale * pulseScaleMultiplier;
        elapsed = 0f;

        while (elapsed < pulseAnimationDuration)
        {
            gameButton.transform.localScale = Vector3.Lerp(gameButtonScale * pulseScaleMultiplier, gameButtonScale, elapsed / pulseAnimationDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        gameButton.transform.localScale = gameButtonScale;
    }
}