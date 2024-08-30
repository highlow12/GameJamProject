using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 추가된 코드: UI 관련 기능을 사용하기 위한 네임스페이스
public enum GameState
{
    Start,
    Running,
    Event,
    Select,
    End
}

public enum MaterialType
{
    Cotton,
    Leather,
    Tencel,
    Unset
}
public enum PojangType
{
    Paper,
    Aircap,
    Vinil
}
public enum MinigameResult
{
    Success,
    Fail
}
public class GameManager : Singleton<GameManager>
{
    public float gameTime;
    public MaterialType materialType;
    public PojangType pojangType;
    public MinigameResult Minigame1Result;
    public MinigameResult Minigame2Result;
    public Action startAction;
    public Action runningAction;
    public Action eventAction;
    public Action selectAction;
    public GameState gameState = GameState.Select;
    public int TMP = 0;
    public int money = 0;
    public int envPoint { get; set; }
    public Text moneyText; // 추가된 변수: 돈 UI 텍스트
    public GameObject endingUIPanel; // 엔딩 UI 패널

    public Button yesButton; 
    public Button noButton; 
    public int endingGoldAmount = 50000; // 우주선 탑승을 위한 최소 금액
    public bool hiddenEnd = false;
    new void Awake()
    {
        runningAction += UpdateTime;
    }

    void Start()
    {
        UpdateMoneyText(); // 게임 시작 시 돈 UI 업데이트

        if (endingUIPanel != null)
        {
            endingUIPanel.SetActive(false);
        }

        // 버튼 이벤트 리스너 추가
        if (yesButton != null)
        {
            yesButton.onClick.AddListener(() => HandleEndingChoice(true));
        }
        if (noButton != null)
        {
            noButton.onClick.AddListener(() => HandleEndingChoice(false));
        }
    }

    void FixedUpdate()
    {
        switch (gameState)
        {
            case GameState.Start:
                if (startAction != null)
                {
                    startAction();
                }
                gameState = GameState.Running;
                break;
            case GameState.Running:
                if (runningAction != null)
                {
                    runningAction();
                }
                CheckForEnding(); // 엔딩 조건 체크
                break;
            case GameState.Event:
                if (eventAction != null)
                {
                    eventAction();
                }
                break;
            case GameState.Select:
                if (selectAction != null)
                {
                    selectAction();
                }
                break;
            case GameState.End:
                break;
        }
    }
    void ChooseEnding()
    {
        int goodEndingPoint = 100;
        int nomalEndingPoint = 50;
        int badEndingPoint = 20;
        if (envPoint >= goodEndingPoint)
        {
            // 좋은 엔딩 처리
        }
        else if (envPoint > nomalEndingPoint)
        {
            // 보통 엔딩 처리
        }
        else if (envPoint > badEndingPoint)
        {
            // 나쁜 엔딩 처리
        }
    }

    public void UpdateTime()
    {
        gameTime += 0.02f;
        gameTime = (float)Math.Round(gameTime, 2);
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyText(); // 돈을 추가할 때마다 UI 텍스트 업데이트
    }
    public void AddEnvPoint(int amount)
    {
        envPoint += amount;
    }
    private void UpdateMoneyText() // 돈 UI 텍스트를 업데이트하는 메서드
    {
        if (moneyText != null)
        {
            moneyText.text = "현재 돈: " + money.ToString() + "원";
        }
    }

    private void CheckForEnding() // 엔딩 조건을 확인하는 메서드
    {
        if (money >= endingGoldAmount && gameState == GameState.Running)
        {
            gameState = GameState.Event; // 게임 상태를 Event로 변경
            ShowEndingUI(); // 엔딩 UI 표시
        }
    }

    private void ShowEndingUI() // 엔딩 UI를 표시하는 메서드
    {
        if (endingUIPanel != null)
        {
            endingUIPanel.SetActive(true);
        }
    }

    private void HandleEndingChoice(bool choice) // 엔딩 선택을 처리하는 메서드
    {
        if (choice) // '예' 선택
        {
            AddMoney(-endingGoldAmount); // 돈 차감
            // 좋은 엔딩으로 진행
            Debug.Log("우주선에 탑승하여 좋은 엔딩으로!");
        }
        else // '아니오' 선택
        {
            // 배드엔딩 처리
            Debug.Log("배드엔딩: 우주선을 타지 않았습니다.");
        }
        endingUIPanel.SetActive(false); // 엔딩 UI 비활성화
        gameState = GameState.End; // 게임 상태를 End로 변경
    }
}
