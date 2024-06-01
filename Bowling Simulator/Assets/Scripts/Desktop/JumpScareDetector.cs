using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    private Vector2 originalPosition;
    public RectTransform otherIcon;
    public Image jumpscare;
    public float iconSize = 128f;
    public AudioSource jumpscareSound;

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (IsOverlapping(otherIcon))
        {
            StopAllCoroutines();
            transform.position = originalPosition;
            StartCoroutine(PlayJumpScare());
        }
    }

    private IEnumerator PlayJumpScare()
    {
        jumpscare.gameObject.SetActive(true);
        jumpscareSound.Play();
        yield return new WaitWhile(() => jumpscareSound.isPlaying);
        jumpscare.gameObject.SetActive(false);
    }

    private bool IsOverlapping(RectTransform other)
    {
        Vector2 thisCenter = ((RectTransform)transform).position;
        Vector2 otherCenter = other.position;

        return Mathf.Abs(thisCenter.x - otherCenter.x) < iconSize && Mathf.Abs(thisCenter.y - otherCenter.y) < iconSize;
    }
}
