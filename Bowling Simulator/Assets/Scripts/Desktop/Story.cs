using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public GameObject icons;
    public Button gameButton;
    public Image cmdWindow;
    public Image chatWindow;
    public Image chatBubble_1;
    public Image chatBubble_2;
    public Image chatBubble_3;
    public Image rightsWindow;
    public float pulseScaleMultiplier = 1.1f;
    public float pulseAnimationDuration = 0.5f;
    public float downloadAnimationDuration = 0.5f;
    public float cmdShowDuration = 1.5f;
    public AudioClip windowOpenClip;
    public AudioClip windowCloseClip;
    public AudioClip messageClip;
    private AudioSource windowOpenSound;
    private AudioSource windowCloseSound;
    private AudioSource messageSound;

    void Start()
    {
        //SceneManager.LoadScene("BowlingScene", LoadSceneMode.Additive);
        //return;
        windowOpenSound = gameObject.AddComponent<AudioSource>();
        windowOpenSound.clip = windowOpenClip;
        windowCloseSound = gameObject.AddComponent<AudioSource>();
        windowCloseSound.clip = windowCloseClip;
        messageSound = gameObject.AddComponent<AudioSource>();
        messageSound.clip = messageClip;
        if(GameState.StoryStage == StoryStages.DesktopWelcome)
            StartCoroutine(PlayBegginingStory());
        else if(GameState.StoryStage == StoryStages.DesktopAnomaly)
            StartCoroutine(PlayFirstAnomaly());
        else if(GameState.StoryStage == StoryStages.RightsAnomaly)
            StartCoroutine(PlayRightsAnomaly());
        else if(GameState.StoryStage == StoryStages.RightsAnomalyForced)
            StartCoroutine(PlayRightsAnomalyForced());
    }

    private IEnumerator PlayBegginingStory()
    {
        gameButton.gameObject.SetActive(false);

        yield return new WaitForSeconds(4f);
        GameState.UiBlocked = true;
        GameState.NextStage();
        windowOpenSound.Play();
        chatWindow.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        messageSound.Play();
        chatBubble_1.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        messageSound.Play();
        chatBubble_2.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        messageSound.Play();
        chatBubble_3.gameObject.SetActive(true);
    }

    private IEnumerator PlayFirstAnomaly()
    {
        ChangePositionOfIcons();

        yield return new WaitForSeconds(1f);
        GameState.UiBlocked = true;
        cmdWindow.gameObject.SetActive(true);
        yield return StartCoroutine(FadeImage(cmdWindow, 0f, 1f, 0.1f));
        yield return new WaitForSeconds(cmdShowDuration);
        yield return StartCoroutine(FadeImage(cmdWindow, 1f, 0f, 0.1f));
        GameState.UiBlocked = false;
        cmdWindow.gameObject.SetActive(false);
    }

    private IEnumerator PlayRightsAnomaly()
    {
        GameState.UiBlocked = true;
        yield return new WaitForSeconds(1f);
        rightsWindow.gameObject.SetActive(true);
        TMP_Text yesText = rightsWindow.transform.GetChild(1).GetComponent<Button>().transform.GetChild(0).GetComponent<TMP_Text>();
        yesText.text = "Nie";
        yield return StartCoroutine(FadeImage(rightsWindow, 0f, 1f, 0.1f));
    }

    private IEnumerator PlayRightsAnomalyForced()
    {
        GameState.UiBlocked = true;
        yield return new WaitForSeconds(1f);
        rightsWindow.gameObject.SetActive(true);
        TMP_Text yesText = rightsWindow.transform.GetChild(1).GetComponent<Button>().transform.GetChild(0).GetComponent<TMP_Text>();
        yesText.text = "Tak";
        yield return StartCoroutine(FadeImage(rightsWindow, 0f, 1f, 0.1f));
    }

    public void RightsWindow_YesButton()
    {
        rightsWindow.gameObject.SetActive(false);
        GameState.UiBlocked = false;
    }

    public void RightsWindow_NoButton()
    {
        rightsWindow.gameObject.SetActive(false);
        GameState.UiBlocked = false;
    } 

    public void DownloadGame()
    {
        StartCoroutine(SimulateDownloading());
    }

    private IEnumerator SimulateDownloading()
    {
        Button downloadLinkButton = chatBubble_3.transform.GetChild(1).GetComponent<Button>();
        downloadLinkButton.enabled = false;

        Image downloadImage = chatBubble_3.transform.GetChild(2).GetComponent<Image>();
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
        downloadLinkButton.enabled = true;
        GameState.UiBlocked = false;
        yield return new WaitForSeconds(0.2f);
        GameState.NextStage();
        yield return StartCoroutine(PulseButton());
    }

    private void ChangePositionOfIcons()
    {
        Vector2[] positions = new Vector2[]
        {
            new (-750, -300),
            new (-500, -300),
            new (-250, -300),
            new (0, -300),
            new (250, -300),
            new (500, -300),
            new (750, -300)
        };

        for (int i = 0; i < icons.transform.childCount; i++)
        {
            if (i < positions.Length)
            {
                GameObject icon = icons.transform.GetChild(i).gameObject;
                icon.transform.localPosition = positions[i];
            }
            else
                Debug.LogWarning("Wiêcej ikon ni¿ pozycji w tablicy");
        }
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
