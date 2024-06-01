using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteIcon : MonoBehaviour, IEndDragHandler
{
    private Vector2 originalPosition;
    public RectTransform trashIcon;
    public float iconSize = 128f;

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (IsOverlapping(trashIcon))
        {
            StopAllCoroutines();
            gameObject.SetActive(false);
            transform.position = originalPosition;
        }
    }

    private bool IsOverlapping(RectTransform other)
    {
        Vector2 thisCenter = ((RectTransform)transform).position;
        Vector2 otherCenter = other.position;

        return Mathf.Abs(thisCenter.x - otherCenter.x) < iconSize && Mathf.Abs(thisCenter.y - otherCenter.y) < iconSize;
    }
}
