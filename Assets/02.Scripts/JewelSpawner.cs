using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelSpawner : MonoBehaviour
{   
    // 보석프리팹을 담아둘 리스트
    public GameObject[] jewels;

    // 풀링 오브젝트를 위한 생성 장소 지정
    private Vector2 poolPosition = new Vector2(0, -35);

    private void OnEnable()
    {
        // 보석 생성 확률 
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
        // 게임오버 상태에서는 동작하지 않음
        if (GameManager.instance.isGameOver) return;

        Jewelspawn();

    }

    void Jewelspawn()
    {
        // PlayerController.items.Length ==> 기억이 안나..ㅎ 어디에 쓰라고 써주셨던거지..ㅠㅠ
       
        // 아이템 슬롯 안에 이미 존재하는 경우 해당 보석은 생성하지 않음
        // jewels 안에 있는 것과 Playercontroller.items안에 있는것 비교
        // PlayerController.items in jewels 

    }
}