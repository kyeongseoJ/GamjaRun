using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamjaitem : MonoBehaviour
{
    // 체력 아이템 오브젝트들을 담는 배열
    public GameObject[] gamjas;

    private void OnEnable()
    {
        // 몹의 수만큼 루프
        for (int i = 0; i < gamjas.Length; i++)
        {
            gamjas[i].SetActive(Random.Range(0, 7) == 0 ? true : false);

        }
    }
}
