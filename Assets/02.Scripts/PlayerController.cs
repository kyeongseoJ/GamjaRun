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

    // 보석을 다 모으면 애니메이션 재생 판단
    private bool isFulled = false;

    //public static string[] items = new string[7];

    // JoyStick1 스크립트 이동 
    public JoystickValue value;


    //이동구현 
    float moveX, moveY;

    [Header("이동속도")]
    [SerializeField] [Range(1f, 30f)] float moveSpeed = 6f;

    void Start()
    {
        // 전역변수의 초기화 진행
        // 게임 오브젝트로부터 사용할 컴포넌트들을 가져와 변수에 할당
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        // 플레이어 사망 시 더이상 움직임 처리 안함
        if (isDead) return;
        // 플레이어 이동
        PlayerMove();
        transform.Translate(value.joyTouch);
        
        // 변신
        SweetPotato();
           
    }

    void PlayerMove()
    {
        //이동 (상 : WS키 혹은 상하이동키)
        //moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * moveSpeed;
        moveX = Input.GetAxis("Horizontal") * moveSpeed;

        //transform.position.y += (moveY*moveSpeed*Time.deltaTime;
        transform.position += new Vector3(moveX, moveY, 0) * Time.deltaTime;

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

    void SweetPotato()
    {
        if (PickUp.countinven == 7)
        {
            animator.SetBool("Fulled", isFulled);
            isFulled = true;
            GameManager.instance.OnPlayerEndding();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌이 일어날 떄 충돌한 상대방의이름을 배열로 넣어준다
        //if(collision.tag == "Jewel")
        //{
        //    for (int i = 0; i < 7; i++)
        //    {
        //        items[i] = collision.name;
        //        // 근데 여기서 이름 넣은거랑 동일한지 판별해서 생성 안되게 하는거랑
        //        // 연관이... 있습니다.
        //    }
        //}
        if (collision.tag == "Dead" && !isDead && GameManager.instance.hp > 0)
        {
           
            GameManager.instance.hp--;
            GameManager.instance.HpUpdate();
            collision.gameObject.SetActive(false);
        }
        if (collision.tag == "Dead" && !isDead && GameManager.instance.hp == 0)
        {
            Die();
        }
        // 충돌한 태그가 gamja이고 살아있다면 hp ++ 처리
        if (collision.tag == "gamja" && !isDead)
        {
            GameManager.instance.hp++;
            GameManager.instance.HpUpdate();
            collision.gameObject.SetActive(false);

        }


    }

}