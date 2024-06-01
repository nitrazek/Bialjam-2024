using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSlider : MonoBehaviour
{
    public GameObject parentObject;
    private float[] intervals = new float[] { 0.2f, 0.3f, 0.4f, 0.7f, 0.4f, 0.2f, 0.2f, 0.1f, 0.1f, 0.1f };
    private float transitionInterval = 0.3f;

    void Start()
    {
        if (parentObject.transform.childCount != intervals.Length)
        {
            Debug.LogError("Liczba dzieci w parentObject musi byæ równa d³ugoœci tablicy intervals.");
            return;
        }

        StartCoroutine(ShowProgressQubes());
    }

    IEnumerator ShowProgressQubes()
    {
        for (int i = 0; i < parentObject.transform.childCount; i++)
        {
            yield return new WaitForSeconds(intervals[i]);
            parentObject.transform.GetChild(i).gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(transitionInterval);
        SceneManager.LoadScene("DesktopScene");
    }
}
