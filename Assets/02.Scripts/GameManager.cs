using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// ���ӿ��� ���¸� ǥ���ϰ�, ���������� UI�� �����ϴ� �Ŵ���
// ������ �� �ϳ��� ���� �Ŵ����� ������ �� �ִ�.
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // �̱����� �Ҵ��� ���� ����

    public bool isGameOver = false; // ���ӿ��� ���¸� ǥ���ϴ� ���� false : Gameover   true : Not Gameover 
    public Text scoreText; // ������ ����� UI �ؽ�Ʈ
    public GameObject gameoverUI; // ���ӿ����� Ȱ��ȭ�� UI ������Ʈ

    private int score = 0; // ���� ����

    public int hp = 2; // ü�� ���� ����
    public Text hpText; // ü��ǥ���� UI �ؽ�Ʈ

    public GameObject menuPanel; // �޴� Ŭ���� �г� Ȱ��ȭ�� ���� UI ������Ʈ


    public bool isPause = false;// �Ͻ����� ����

    // �ְ������ ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText;


    // ���� ���۰� ���ÿ� �̱����� ����
    private void Awake()
    {

        // �̱��� ���� instance �� ��� �ֳ���?
        if (instance == null)
        {
            // instance�� ����ִٸ� �װ��� �� �ڽ��� �Ҵ�
            instance = this; 
        }
        else
        {
            Debug.Log("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);
        }
    }

    // ���� ���� ���¿��� ������ ����� �� �� �ְ� �ϴ� ó�� ����
    void Update()
    {
        // ���� ���� ���¿��� ����ڰ� ���콺 ���� ��ư�� Ŭ���Ѵٸ�
        if (isGameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    
    // ���� ui
    public void AddScore(int newScore)
    {
        // ���ӿ����� �ƴ϶��
        if (!isGameOver)
        {
            // ������ ����
            score += newScore;
            // ���ھ UI�� ǥ��
            scoreText.text = "Score : " + score;
        }
    }

    // �÷��̾ ��� �� ���� ������ �����ϴ� �޼���
    public void OnPlayerDead()
    {
        // ���ӿ��� 
        isGameOver = true;
        // ���ӿ��� �ؽ�Ʈ Ȱ��ȭ
        gameoverUI.SetActive(true);

    }

    // ü�� ���� ǥ��
    public void HpUpdate()
    {
        // ü�� ���ҵ� ���� �ؽ�Ʈ �ȿ� �ۼ�
        hpText.text = "HP " + hp;

    }

    // �޴� Ŭ���� ȭ�� �Ͻ����� �� �г� Ȱ��ȭ
    public void OnMenu()
    {
        if (!isPause)
        {   // �Ͻ����� ���� �ƴϸ� �Ͻ�����
            Time.timeScale = 0; // �ð�����
            // �г�Ȱ��ȭ
            menuPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f; // �ð��帧 ���� 1
            menuPanel.SetActive(false);
        }

        isPause = !isPause; // �޴� ���� ������ ���°� �ݴ�� �ٲ�
    }

    // ����� 
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }

    // Ȩ ȭ������
    public void GoHome()
    {
        SceneManager.LoadScene("Home");
        Time.timeScale = 1.0f;
    }


    // ���� ���� 
    public void ExitGame()
    {
        Application.Quit();
    }

}