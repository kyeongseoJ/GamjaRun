using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelSpawner : MonoBehaviour
{ 
    // 생성할 보석의 원본 프리팹
    public GameObject jewelPrefab;
    // 생성할  보석 수
    public int count = 9;

    // 다음 배치까지의 시간 간격 최솟값
    private float timeBetSpawnMin = 2f;
    // 다음 배치까지의 시간 간격 최댓값
    private float timeBetSpawnMax = 4f;
    // 다음 배치까지의 시간 간격
    public float timeBetSpawn; 

    // 배치할 위치의 최소 x값
    public static float xMin = -2f;
    // 배치할 위치의 최대 x값
    public static float xMax = 8f;
    // 배치할 위치의 y값
    public static float yPos = 0f;

    // 미리 생성한 보석들
    private GameObject[] jewels;

    // 사용할 현재 순번의  보석
    private int currentIndex = 0;

    // 초반에 생성한  보석을 화면 밖에 숨겨둘 위치
    private Vector2 poolPosition = new Vector2(0, -35);
    // 마지막 배치 시점
    private float lastSpawnTime;

    // 변수를 초기화하고 사용할  보석을 미리 생성
    void Start()
    {
        // count 만큼의 공간을 가지는 새로운 보석 배열 생성
        jewels = new GameObject[count];

        // count 루프하면서  보석 생성
        for (int i = 0; i < count; i++)
        {

            jewels[i] = Instantiate(jewelPrefab, poolPosition, Quaternion.identity);
        }

        // 마지막 배치 시점 초기화
        lastSpawnTime = 0f;
        // 다음번 배치까지의 시간 간격을 초기화
        timeBetSpawn = 0f;
    }

    // 순서를 돌아가며 주기적으로 보석 설치
    void Update()
    {
        // 게임오버 상태에서는 동작하지 않음
        if (GameManager.instance.isGameOver) return;

        // 마지막 배치 시점에서 timeBetSpawn이상 시간이 흘렀다면
        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            // 기록된 마지막 배치 시점을 현재 시점으로 갱신
            lastSpawnTime = Time.time;
            // 다음 배치까지의 시간 간격을 timeBetSpawnMin, timeBetSpawnMax 사이에서 랜덤 설정
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
            // 배치할 위치의 높이를 일정하게 지정
            float yPos = 1f;


            // 사용할 현재 순번의 보석, 게임의 오브젝트를 비활성화하고 즉시 다시 활성화
            jewels[currentIndex].SetActive(false);
            jewels[currentIndex].SetActive(true);


            // 현재 순반의 보석을 화면 오른쪽에 배치
            jewels[currentIndex].transform.position = new Vector2(18, yPos);

            // 순번 넘기기
            currentIndex++;

            // 마지막 순번에 도달했다면 순번을 리셋
            if (currentIndex >= count)
            {
                currentIndex = 0;
            }
        }
    }


}