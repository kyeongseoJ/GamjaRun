using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    // 장애물 오브젝트들을 담는 배열
    public GameObject[] mobs;

    private void OnEnable()
    {
        // 몹의 수만큼 루프
        for (int i = 0; i < mobs.Length; i++)
        {
            mobs[i].SetActive(Random.Range(0, 4) == 0 ? true : false);

        }
    }

}
