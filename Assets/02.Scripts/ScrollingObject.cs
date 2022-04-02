using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ������Ʈ�� ���������� �������� �����̴� ��ũ��Ʈ
public class ScrollingObject : MonoBehaviour
{
    // �̵� �ӵ�
    public float speed = 3f;
 

    void Update()
    {
        if (!GameManager.instance.isGameOver)  // isGameOver�� false ���.. == ����ִٸ� ��������
        {
            // �ʴ� speed�� �ӵ��� �������� �����̵� ����
            // ��ġ���� ���� ������ ó��
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

}
