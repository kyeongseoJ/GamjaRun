using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    // ���̽�ƽ UI �� ��� �̹��� ����
    [SerializeField] private RectTransform rect_Background;
    // ���̽�ƽ UI �� ��Ʈ�ѷ�(�ڵ�) �̹��� ����
    [SerializeField] private RectTransform rect_JoyStick;

    private float radius;
   
    [SerializeField] private GameObject go_Player;
    [SerializeField] private float moveSpeed;

    // ���̽�ƽ�� ���������� �ܺ� Ŭ�������� ����� �� �ֵ��� ���� ���� ����
    private bool isTouch = false;
    private Vector3 movePosition;

    private void Start()
    {
        radius = rect_Background.rect.width * 0.5f;
    }

    private void Update()
    {
        if (isTouch)
        {
            go_Player.transform.position += movePosition;
        }
    }

    // ���̽�ƽ ���� ���� ������ �̻� �������� ���� ���� 
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = eventData.position - (Vector2)rect_Background.position;

        value = Vector2.ClampMagnitude(value, radius);
        rect_JoyStick.localPosition = value;

        // 
        float distance = Vector2.Distance(rect_Background.position, rect_JoyStick.position) / radius;
        // value ���� ����ȭ [-1 ~ 1]
        value = value.normalized;
        // ���� ���̽�ƽ ��Ʈ�ѷ� �̹��� �̵�
        movePosition = new Vector3(value.x * moveSpeed * distance * Time.deltaTime, 0f, value.y * moveSpeed * distance * Time.deltaTime);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = true;
        // ��ġ ���� �� �̹����� ��ġ�� �߾����� �ٽ� �ű��.
        rect_JoyStick.localPosition = Vector3.zero;
        // �ٸ� ������Ʈ���� �̵� �������� ����ϱ� ������ �̵� ���⵵ �ʱ�ȭ
        movePosition = Vector3.zero;
    }
}
