using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour
{
    public Canvas canvas;
    public GameObject windowToOpen;
    public RawImage sceneFrame;
    protected bool IsDragging;

    public void Button_Drag(BaseEventData eventData)
    {
        if (GameState.UiBlocked) return;
        if (!IsDragging) IsDragging = true;
        transform.SetAsLastSibling();

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

    public void Button_Drag_End(BaseEventData eventData)
    {
        IsDragging = false;
    }

    public void Window_Open()
    {
        if (GameState.UiBlocked || IsDragging || sceneFrame.gameObject.activeSelf)
            return;

        windowToOpen.SetActive(true);
    }
}
