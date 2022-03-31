using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ���� ������ �̵��� ����� ������ ������ ���ġ ó��
public class BackgroundLoop : MonoBehaviour
{
    // ����� ���α���
    private float width;

    // Unity Event Method 
    private void Awake()
    {
        // ���� ���̸� ����(���������� �����ͼ� �ٷ� �Ҵ� �� ���̴�)
        // BoxCollider2D ������Ʈ�� Size �ʵ��� X���� ���� ���̷� ���
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;

    }

    void Update()
    {
        // ���� ��ġ�� �������� �������� width�̻� �̵����� �� ��ġ�� ���ġ
        if (transform.position.x <= -width)
        {
            Reposition();
        }
    }

    void Reposition() // ��ġ�� ���ġ�ϴ� �ż���
    {
        // ���� ��ġ���� ���������� ���α��� * 2 ��ŭ �̵�
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
        // width * 2  = 20.48 * 2 - 40.96
        // -20.48  + 40.96 = 20.48
    }
}