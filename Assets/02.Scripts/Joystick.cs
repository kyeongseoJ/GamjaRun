using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    // 조이스틱 UI 중 배경 이미지 변수
    [SerializeField] private RectTransform rect_Background;
    // 조이스틱 UI 중 컨트롤러(핸들) 이미지 변수
    [SerializeField] private RectTransform rect_JoyStick;

    private float radius;
   
    [SerializeField] private GameObject go_Player;
    [SerializeField] private float moveSpeed;

    // 조이스틱의 방향정보를 외부 클래스에서 사용할 수 있도록 전역 변수 설정
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

    // 조이스틱 안의 원이 반지름 이상 못나가게 영역 제한 
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = eventData.position - (Vector2)rect_Background.position;

        value = Vector2.ClampMagnitude(value, radius);
        rect_JoyStick.localPosition = value;

        // 
        float distance = Vector2.Distance(rect_Background.position, rect_JoyStick.position) / radius;
        // value 값의 정규화 [-1 ~ 1]
        value = value.normalized;
        // 가상 조이스틱 컨트롤러 이미지 이동
        movePosition = new Vector3(value.x * moveSpeed * distance * Time.deltaTime, 0f, value.y * moveSpeed * distance * Time.deltaTime);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = true;
        // 터치 종료 시 이미지의 위치를 중앙으로 다시 옮긴다.
        rect_JoyStick.localPosition = Vector3.zero;
        // 다른 오브젝트에서 이동 방향으로 사용하기 때문에 이동 방향도 초기화
        movePosition = Vector3.zero;
    }
}
