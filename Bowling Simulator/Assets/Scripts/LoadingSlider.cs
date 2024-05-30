using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSlider : MonoBehaviour
{
    public Slider loadingSlider;
    public float loadDuration = 1.0f;
    public int pausePoints = 3;
    public float pauseDuration = 0.2f;
    void Start()
    {
        StartCoroutine(SimulateLoading());
    }

    private IEnumerator SimulateLoading()
    {
        float elapsedTime = 0f;
        float stepDuration = loadDuration / (pausePoints + 1);
        float[] pausePositions = new float[pausePoints];

        for (int i = 0; i < pausePoints; i++)
        {
            pausePositions[i] = Random.Range(stepDuration * i, stepDuration * (i + 1));
        }

        int currentPauseIndex = 0;

        while (elapsedTime < loadDuration)
        {
            if (currentPauseIndex < pausePoints && elapsedTime >= pausePositions[currentPauseIndex])
            {
                yield return new WaitForSeconds(pauseDuration);
                currentPauseIndex++;
            }
            else
            {
                elapsedTime += Time.deltaTime;
                loadingSlider.value = elapsedTime / loadDuration;
            }
            yield return null;
        }

        loadingSlider.value = 1f;
        yield return new WaitForSeconds(pauseDuration);
        SceneManager.LoadScene("DesktopScene");
    }
}
