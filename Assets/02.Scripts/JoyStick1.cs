using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    RectTransform rect;
    Vector2 touch = Vector2.zero;
    public RectTransform handle;

    float widthHalf;

    public JoystickValue value;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
        widthHalf = rect.sizeDelta.x * 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 터치된 좌표
        touch = (eventData.position - rect.anchoredPosition)/ widthHalf;
        if(touch.magnitude > 1)
        {
            touch = touch.normalized;
        }
        value.joyTouch = touch*0.3f;
        // 작은 원 이동반경
        handle.anchoredPosition = touch * widthHalf;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    // 핸들 손에서 떼면 제자리로(가운데원점으로)
    public void OnPointerUp(PointerEventData eventData)
    {
        value.joyTouch = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}
