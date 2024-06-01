using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveWindow : MonoBehaviour
{
    public Canvas canvas;
    public void Window_Drag(BaseEventData eventData)
    {
        PointerEventData pointerEventData = (PointerEventData)eventData;
        Vector3 pointerPosition = pointerEventData.position;
        pointerPosition.y -= GetComponent<RectTransform>().rect.height / 2;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            pointerPosition,
            canvas.worldCamera,
            out position);

        Debug.Log(position);

        transform.position = canvas.transform.TransformPoint(position);
    }

    public void Window_Close()
    {
        gameObject.SetActive(false);
    }
}
