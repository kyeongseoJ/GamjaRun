using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamjaitem : MonoBehaviour
{
    // ü�� ������ ������Ʈ���� ��� �迭
    public GameObject[] gamjas;

    private void OnEnable()
    {
        // ���� ����ŭ ����
        for (int i = 0; i < gamjas.Length; i++)
        {
            gamjas[i].SetActive(Random.Range(0, 7) == 0 ? true : false);

        }
    }
}
