using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    // 생성할 몹의 원본 프리팹
    public GameObject mobPrefab;
    // 생성할 몹 수
    public int count = 5;

    // 다음 배치까지의 시간 간격 최솟값
    public float timeBetSpawnMin = 0.5f;
    // 다음 배치까지의 시간 간격 최댓값
    public float timeBetSpawnMax = 2.5f;
    // 다음 배치까지의 시간 간격
    public float timeBetSpawn;

    // 배치할 위치의 최소 x값
    public static float xMin = -2f;
    // 배치할 위치의 최대 x값
    public static float xMax = 8f;
    // 배치할 위치의 y값
    public static float yPos = 0f;

    // 미리 생성한 몹들
    private GameObject[] mobs;
    // 사용할 현재 순번의 몹
    private int currentIndex = 0;

    // 초반에 생성한 몹을 화면 밖에 숨겨둘 위치
    private Vector2 poolPosition = new Vector2(0, -25);
    // 마지막 배치 시점
    private float lastSpawnTime;

    // 변수를 초기화하고 사용할 몹을 미리 생성
    void Start()
    {
        // count 만큼의 공간을 가지는 새로운 몹 배열 생성
        mobs = new GameObject[count];
        // count 루프하면서 몹 생성
        for (int i = 0; i < count; i++)
        {
            // mobPrefab을 원본으로 새 몹을 poolPosition 위치에 복제 생성
            // 생성된 몹을 mobs 배열에 할당
            mobs[i] = Instantiate(mobPrefab, poolPosition, Quaternion.identity);
           
        }

        // 마지막 배치 시점 초기화
        lastSpawnTime = 0f;
        // 다음번 배치까지의 시간 간격을 초기화
        timeBetSpawn = 0f;
    }

    // 순서를 돌아가며 주기적으로 몹 설치
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
            float yPos = 0f;


            // 사용할 현재 순번의 몹, 게임의 오브젝트를 비활성화하고 즉시 다시 활성화
            // 이때 몹의 Platform 컴포넌트와 OnEnable 메서드가 실행됨
            mobs[currentIndex].SetActive(false);
            mobs[currentIndex].SetActive(true);

            // 현재 순반의 몹을 화면 오른쪽에 배치
            mobs[currentIndex].transform.position = new Vector2(15, yPos);

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
