using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamjaSpawner : MonoBehaviour
{
    // ������ ������ ���� ������
    public GameObject gamjaPrefab;
    // ������ ���� ������ ���� ������
    public GameObject rottenPrefab;

    // ������  ���� ��
    public int count = 3;

    // ���� ��ġ������ �ð� ���� �ּڰ�
    public float timeBetSpawnMin = 1f;
    // ���� ��ġ������ �ð� ���� �ִ�
    public float timeBetSpawnMax = 5f;
    // ���� ��ġ������ �ð� ����
    public float timeBetSpawn;

    // ��ġ�� ��ġ�� �ּ� x��
    public static float xMin = -2f;
    // ��ġ�� ��ġ�� �ִ� x��
    public static float xMax = 8f;
    // ��ġ�� ��ġ�� y��
    public static float yPos = 0f;

    // �̸� ������ ���ڵ�
    private GameObject[] gamjas;
    // �̸� ������  ���ڵ�
    private GameObject[] rottengamjas;

    // ����� ���� ������  ����
    private int currentIndex = 0;

    // �ʹݿ� ������  ���ڸ� ȭ�� �ۿ� ���ܵ� ��ġ
    private Vector2 poolPosition = new Vector2(0, -45);
    // ������ ��ġ ����
    private float lastSpawnTime;

    // ������ �ʱ�ȭ�ϰ� �����  ���ڸ� �̸� ����
    void Start()
    {
        // count ��ŭ�� ������ ������ ���ο�  ���� �迭 ����
        gamjas = new GameObject[count];
        rottengamjas = new GameObject[count];

        // count �����ϸ鼭  ���� ����
        for (int i = 0; i < count; i++)
        {
            // gamjasPrefab�� �������� ��  ���ڸ� poolPosition ��ġ�� ���� ����
            // ������  ���ڸ� gamjas �迭�� �Ҵ�
            gamjas[i] = Instantiate(gamjaPrefab, poolPosition, Quaternion.identity);
            rottengamjas[i] = Instantiate(rottenPrefab, poolPosition, Quaternion.identity);
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
            float yPos = 1.5f;


            // ����� ���� ������ ��, ������ ������Ʈ�� ��Ȱ��ȭ�ϰ� ��� �ٽ� Ȱ��ȭ
            // �̶� ���� Platform ������Ʈ�� OnEnable �޼��尡 �����
            gamjas[currentIndex].SetActive(false);
            gamjas[currentIndex].SetActive(true);

            rottengamjas[currentIndex].SetActive(false);
            rottengamjas[currentIndex].SetActive(true);

            
            // ���� ������ ���� ȭ�� �����ʿ� ��ġ
            gamjas[currentIndex].transform.position = new Vector2(18, yPos);
            rottengamjas[currentIndex].transform.position = new Vector2(23, yPos);

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
