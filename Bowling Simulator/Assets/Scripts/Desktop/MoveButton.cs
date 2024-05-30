using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButton : MonoBehaviour
{
    public bool IsDragging { get; private set; }
    public Canvas canvas;

    public void Button_Drag_Start()
    {
        IsDragging = true;
    }

    public void Button_Drag_End()
    {
        IsDragging = false;
    }

    public void Button_Drag(BaseEventData eventData)
    {
        PointerEventData pointerEventData = (PointerEventData)eventData;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            pointerEventData.position,
            canvas.worldCamera,
            out position);

        Debug.Log(position);

        transform.position = canvas.transform.TransformPoint(position);
    }
}
