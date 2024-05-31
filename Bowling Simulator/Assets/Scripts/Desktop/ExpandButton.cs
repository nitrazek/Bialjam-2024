using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExpandButton : MonoBehaviour
{
    private Vector3 originalScale;
    public float scaleMultiplier = 1.1f;
    public float animationDuration = 0.2f;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(BaseEventData eventData)
    {
        if (GameState.UiBlocked) return;
        StopAllCoroutines();
        StartCoroutine(ScaleButton(transform.localScale, originalScale * scaleMultiplier, animationDuration));
    }

    public void OnPointerExit(BaseEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(ScaleButton(transform.localScale, originalScale, animationDuration));
    }

    private IEnumerator ScaleButton(Vector3 from, Vector3 to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = to;
    }
}
