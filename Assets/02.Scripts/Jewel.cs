using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewel : MonoBehaviour
{
    // 보석프리팹을 담아둘 리스트
    public GameObject[] jewels;  

    private void OnEnable()
    {
        // 보석 생성 확률 
        for (int i = 0; i < jewels.Length; i++)
        {
            jewels[i].SetActive(Random.Range(0, 6) == 0 ? true : false);
        }
    }



}

