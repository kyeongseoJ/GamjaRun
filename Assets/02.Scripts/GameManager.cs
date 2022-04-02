using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 게임오버 상태를 표현하고, 게임점수와 UI를 관리하는 매니저
// 씬에는 단 하나의 게임 매니저만 존재할 수 있다.
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글턴을 할당할 전역 변수

    public bool isGameOver = false; // 게임오버 상태를 표현하는 변수 false : Gameover   true : Not Gameover 
    public Text scoreText; // 점수를 출력할 UI 텍스트
    public GameObject gameoverUI; // 게임오버시 활성화할 UI 오브젝트

    private int score = 0; // 게임 점수

    public int hp = 2; // 체력 변수 설정
    public Text hpText; // 체력표시할 UI 텍스트

    public GameObject menuPanel; // 메뉴 클릭시 패널 활성화를 위한 UI 오브젝트


    public bool isPause = false;// 일시정지 상태

    // 최고기록을 표시할 텍스트 컴포넌트
    public Text recordText;


    // 게임 시작과 동시에 싱글턴을 구성
    private void Awake()
    {

        // 싱글턴 변수 instance 가 비어 있나요?
        if (instance == null)
        {
            // instance가 비어있다면 그곳에 내 자신을 할당
            instance = this; 
        }
        else
        {
            Debug.Log("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    // 게임 오버 상태에서 게임을 재시작 할 수 있게 하는 처리 구현
    void Update()
    {
        // 게임 오버 상태에서 사용자가 마우스 왼쪽 버튼을 클릭한다면
        if (isGameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    
    // 점수 ui
    public void AddScore(int newScore)
    {
        // 게임오버가 아니라면
        if (!isGameOver)
        {
            // 점수를 증가
            score += newScore;
            // 스코어를 UI로 표시
            scoreText.text = "Score : " + score;
        }
    }

    // 플레이어가 사망 시 게임 오버를 실행하는 메서드
    public void OnPlayerDead()
    {
        // 게임오버 
        isGameOver = true;
        // 게임오버 텍스트 활성화
        gameoverUI.SetActive(true);

    }

    // 체력 감소 표시
    public void HpUpdate()
    {
        // 체력 감소된 값을 텍스트 안에 작성
        hpText.text = "HP " + hp;

    }

    // 메뉴 클릭시 화면 일시정지 및 패널 활성화
    public void OnMenu()
    {
        if (!isPause)
        {   // 일시정지 중이 아니면 일시정지
            Time.timeScale = 0; // 시간정지
            // 패널활성화
            menuPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f; // 시간흐름 비율 1
            menuPanel.SetActive(false);
        }

        isPause = !isPause; // 메뉴 누를 때마다 상태가 반대로 바뀜
    }

    // 재시작 
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }

    // 홈 화면으로
    public void GoHome()
    {
        SceneManager.LoadScene("Home");
        Time.timeScale = 1.0f;
    }


    // 게임 종료 
    public void ExitGame()
    {
        Application.Quit();
    }

}