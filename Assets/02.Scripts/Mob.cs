using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    // ��ֹ� ������Ʈ���� ��� �迭
    public GameObject[] mobs;

    private void OnEnable()
    {
        // ���� ����ŭ ����
        for (int i = 0; i < mobs.Length; i++)
        {
            mobs[i].SetActive(Random.Range(0, 4) == 0 ? true : false);

        }
    }

}
