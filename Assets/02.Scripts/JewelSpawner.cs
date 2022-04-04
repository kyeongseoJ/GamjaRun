using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelSpawner : MonoBehaviour
{ 
    // ������ ������ ���� ������
    public GameObject jewelPrefab;
    // ������  ���� ��
    public int count = 9;

    // ���� ��ġ������ �ð� ���� �ּڰ�
    private float timeBetSpawnMin = 2f;
    // ���� ��ġ������ �ð� ���� �ִ�
    private float timeBetSpawnMax = 4f;
    // ���� ��ġ������ �ð� ����
    public float timeBetSpawn; 

    // ��ġ�� ��ġ�� �ּ� x��
    public static float xMin = -2f;
    // ��ġ�� ��ġ�� �ִ� x��
    public static float xMax = 8f;
    // ��ġ�� ��ġ�� y��
    public static float yPos = 0f;

    // �̸� ������ ������
    private GameObject[] jewels;

    // ����� ���� ������  ����
    private int currentIndex = 0;

    // �ʹݿ� ������  ������ ȭ�� �ۿ� ���ܵ� ��ġ
    private Vector2 poolPosition = new Vector2(0, -35);
    // ������ ��ġ ����
    private float lastSpawnTime;

    // ������ �ʱ�ȭ�ϰ� �����  ������ �̸� ����
    void Start()
    {
        // count ��ŭ�� ������ ������ ���ο� ���� �迭 ����
        jewels = new GameObject[count];

        // count �����ϸ鼭  ���� ����
        for (int i = 0; i < count; i++)
        {

            jewels[i] = Instantiate(jewelPrefab, poolPosition, Quaternion.identity);
        }

        // ������ ��ġ ���� �ʱ�ȭ
        lastSpawnTime = 0f;
        // ������ ��ġ������ �ð� ������ �ʱ�ȭ
        timeBetSpawn = 0f;
    }

    // ������ ���ư��� �ֱ������� ���� ��ġ
    void Update()
    {
        // ���ӿ��� ���¿����� �������� ����
        if (GameManager.instance.isGameOver) return;

        // ������ ��ġ �������� timeBetSpawn�̻� �ð��� �귶�ٸ�
        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            // ��ϵ� ������ ��ġ ������ ���� �������� ����
            lastSpawnTime = Time.time;
            // ���� ��ġ������ �ð� ������ timeBetSpawnMin, timeBetSpawnMax ���̿��� ���� ����
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
            // ��ġ�� ��ġ�� ���̸� �����ϰ� ����
            float yPos = 1f;


            // ����� ���� ������ ����, ������ ������Ʈ�� ��Ȱ��ȭ�ϰ� ��� �ٽ� Ȱ��ȭ
            jewels[currentIndex].SetActive(false);
            jewels[currentIndex].SetActive(true);


            // ���� ������ ������ ȭ�� �����ʿ� ��ġ
            jewels[currentIndex].transform.position = new Vector2(18, yPos);

            // ���� �ѱ��
            currentIndex++;

            // ������ ������ �����ߴٸ� ������ ����
            if (currentIndex >= count)
            {
                currentIndex = 0;
            }
        }
    }


}