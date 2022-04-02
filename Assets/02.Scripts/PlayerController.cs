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

    // �浹 �ִϸ��̼� �� ��ȭ�� ���� ������Ʈ ��������
    private SpriteRenderer spriteRenderer;

    public static string[] items = new string[7];


    float moveX, moveY;

    [Header("�̵��ӵ�")]
    [SerializeField] [Range(1f, 30f)] float moveSpeed = 6f;

    void Start()
    {
        // ���������� �ʱ�ȭ ����
        // ���� ������Ʈ�κ��� ����� ������Ʈ���� ������ ������ �Ҵ�
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

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

    //private IEnumerator HitAnimation()
    //{
    //     �÷��̾� ���� ����
    //    spriteRenderer.color = Color.red;
    //    0.1�� ���
    //    yield return new WaitForSeconds(0.1f);
    //     ���� ��������
    //    spriteRenderer.color = Color.white;
    //}

    // Hmm...?
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �浹�� �Ͼ �� �浹�� �������̸��� �迭�� �־��ش�
        if(collision.tag == "Jewel")
        {
            for (int i = 0; i < 7; i++)
            {
                items[i] = collision.name;
                // �ٵ� ���⼭ �̸� �����Ŷ� �������� �Ǻ��ؼ� ���� �ȵǰ� �ϴ°Ŷ� ������ �ֽ��ϴ�.
            }
        }
        if (collision.tag == "Dead" && !isDead && GameManager.instance.hp > 0)
        {
           // HitAnimation();
            GameManager.instance.hp--;
            GameManager.instance.HpUpdate();
            collision.gameObject.SetActive(false);
        }
        if (collision.tag == "Dead" && !isDead && GameManager.instance.hp == 0)
        {
            Die();
        }
        // �浹�� �±װ� gamja�̰� ����ִٸ� hp ++ ó��
        if (collision.tag == "gamja" && !isDead)
        {
            GameManager.instance.hp++;
            GameManager.instance.HpUpdate();
            collision.gameObject.SetActive(false);

        }


    }

}