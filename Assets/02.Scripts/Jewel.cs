using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewel : MonoBehaviour
{
    // ������������ ��Ƶ� ����Ʈ
    public GameObject[] jewels;  

    private void OnEnable()
    {
        // ���� ���� Ȯ�� 
        for (int i = 0; i < jewels.Length; i++)
        {
            jewels[i].SetActive(Random.Range(0, 6) == 0 ? true : false);
        }
    }



}

