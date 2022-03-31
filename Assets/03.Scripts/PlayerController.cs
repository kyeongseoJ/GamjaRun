using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// PlayerController�� �÷��̾� ĳ���ͷμ� Player ���� ������Ʈ�� ������
public class PlayerController : MonoBehaviour
{

    // �÷��̾��� ��� ���� : �׾����� ��Ҵ���
    private bool isDead = false;

    // �̵��� ����� ������ٵ� ������Ʈ
    private Rigidbody2D playerRigidbody;

    // ����� �ִϸ����� ������Ʈ
    private Animator animator;


    float moveX, moveY;

    [Header("�̵��ӵ�")]
    [SerializeField] [Range(1f, 30f)] float moveSpeed = 8f;

    void Start()
    {
        // ���������� �ʱ�ȭ ����
        // ���� ������Ʈ�κ��� ����� ������Ʈ���� ������ ������ �Ҵ�
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // 
    void Update()
    {
        // �÷��̾� ��� �� ���̻� ������ ó�� ����
        if (isDead) return;

        PlayerMove();

    }

    void PlayerMove()
    {
        //�̵� (�� : WSŰ Ȥ�� �����̵�Ű)
        //moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * moveSpeed;
        moveX = Input.GetAxis("Horizontal") * moveSpeed;

        //transform.position.y += (moveY*moveSpeed*Time.deltaTime;
        transform.position += new Vector3(moveX, moveY,0)*Time.deltaTime;

    }

    void Die()
    {
        // ��� ó��
        // ���� �÷��̾ �׾��ٸ� �ִϸ������� Die Ʈ���� �Ķ���͸� Set
        animator.SetTrigger("Die");

        // ����� �ӵ��� ���η� ����
        playerRigidbody.velocity = Vector2.zero;
        // �� ����߾�...������� true�� �����ؼ� �˸�
        isDead = true;

        // ���ӸŴ����� ���ӿ��� ó�� ����(���ӸŴ��� ���� instance�� ����ó���� �ʿ��ϴ�.)
        GameManager.instance.OnPlayerDead();


    }

}