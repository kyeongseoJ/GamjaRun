using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelSpawner : MonoBehaviour
{   
    // ������������ ��Ƶ� ����Ʈ
    public GameObject[] jewels;

    // Ǯ�� ������Ʈ�� ���� ���� ��� ����
    private Vector2 poolPosition = new Vector2(0, -35);

    private void OnEnable()
    {
        // ���� ���� Ȯ�� 
        for (int i = 0; i < jewels.Length; i++)
        {
            jewels[i].SetActive(Random.Range(0, 5) == 0 ? true : false);
        }
    }

    private void Start()
    {
        
    }

    void Update()
    {
        // ���ӿ��� ���¿����� �������� ����
        if (GameManager.instance.isGameOver) return;

        Jewelspawn();

    }

    void Jewelspawn()
    {
        // PlayerController.items.Length ==> ����� �ȳ�..�� ��� ����� ���̴ּ�����..�Ф�
       
        // ������ ���� �ȿ� �̹� �����ϴ� ��� �ش� ������ �������� ����
        // jewels �ȿ� �ִ� �Ͱ� Playercontroller.items�ȿ� �ִ°� ��
        // PlayerController.items in jewels 

    }
}