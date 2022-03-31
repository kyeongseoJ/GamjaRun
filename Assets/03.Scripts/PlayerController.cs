using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어함
public class PlayerController : MonoBehaviour
{

    // 플레이어의 사망 상태 : 죽었는지 살았는지
    private bool isDead = false;

    // 이동에 사용할 리지드바디 컴포넌트
    private Rigidbody2D playerRigidbody;

    // 사용할 애니메이터 컴포넌트
    private Animator animator;


    float moveX, moveY;

    [Header("이동속도")]
    [SerializeField] [Range(1f, 30f)] float moveSpeed = 8f;

    void Start()
    {
        // 전역변수의 초기화 진행
        // 게임 오브젝트로부터 사용할 컴포넌트들을 가져와 변수에 할당
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // 
    void Update()
    {
        // 플레이어 사망 시 더이상 움직임 처리 안함
        if (isDead) return;

        PlayerMove();

    }

    void PlayerMove()
    {
        //이동 (상 : WS키 혹은 상하이동키)
        //moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * moveSpeed;
        moveX = Input.GetAxis("Horizontal") * moveSpeed;

        //transform.position.y += (moveY*moveSpeed*Time.deltaTime;
        transform.position += new Vector3(moveX, moveY,0)*Time.deltaTime;

    }

    void Die()
    {
        // 사망 처리
        // 만약 플레이어가 죽었다면 애니메이터의 Die 트리거 파라미터를 Set
        animator.SetTrigger("Die");

        // 사망시 속도를 제로로 변경
        playerRigidbody.velocity = Vector2.zero;
        // 나 사망했어...사망상태 true로 변경해서 알림
        isDead = true;

        // 게임매니저의 게임오버 처리 실행(게임매니저 안의 instance에 접근처리가 필요하다.)
        GameManager.instance.OnPlayerDead();


    }

}