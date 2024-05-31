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
        pointerPosition.y -= 360;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            pointerPosition,
            canvas.worldCamera,
            out position);

        Debug.Log(position);

        transform.position = canvas.transform.TransformPoint(position);
    }
}
