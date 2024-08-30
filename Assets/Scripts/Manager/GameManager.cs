using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // �߰��� �ڵ�: UI ���� ����� ����ϱ� ���� ���ӽ����̽�
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
    public Text moneyText; // �߰��� ����: �� UI �ؽ�Ʈ
    public GameObject endingUIPanel; // ���� UI �г�
    public Button yesButton; 
    public Button noButton; 
    public int endingGoldAmount = 50000; // ���ּ� ž���� ���� �ּ� �ݾ�

    new void Awake()
    {
        runningAction += UpdateTime;
    }

    void Start()
    {
        UpdateMoneyText(); // ���� ���� �� �� UI ������Ʈ

        if (endingUIPanel != null)
        {
            endingUIPanel.SetActive(false);
        }

        // ��ư �̺�Ʈ ������ �߰�
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
                CheckForEnding(); // ���� ���� üũ
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
            // ���� ���� ó��
        }
        else if (envPoint > nomalEndingPoint)
        {
            // ���� ���� ó��
        }
        else if (envPoint > badEndingPoint)
        {
            // ���� ���� ó��
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
        UpdateMoneyText(); // ���� �߰��� ������ UI �ؽ�Ʈ ������Ʈ
    }
    public void AddEnvPoint(int amount)
    {
        envPoint += amount;
    }
    private void UpdateMoneyText() // �� UI �ؽ�Ʈ�� ������Ʈ�ϴ� �޼���
    {
        if (moneyText != null)
        {
            moneyText.text = "���� ��: " + money.ToString() + "��";
        }
    }

    private void CheckForEnding() // ���� ������ Ȯ���ϴ� �޼���
    {
        if (money >= endingGoldAmount && gameState == GameState.Running)
        {
            gameState = GameState.Event; // ���� ���¸� Event�� ����
            ShowEndingUI(); // ���� UI ǥ��
        }
    }

    private void ShowEndingUI() // ���� UI�� ǥ���ϴ� �޼���
    {
        if (endingUIPanel != null)
        {
            endingUIPanel.SetActive(true);
        }
    }

    private void HandleEndingChoice(bool choice) // ���� ������ ó���ϴ� �޼���
    {
        if (choice) // '��' ����
        {
            AddMoney(-endingGoldAmount); // �� ����
            // ���� �������� ����
            Debug.Log("���ּ��� ž���Ͽ� ���� ��������!");
        }
        else // '�ƴϿ�' ����
        {
            // ��忣�� ó��
            Debug.Log("��忣��: ���ּ��� Ÿ�� �ʾҽ��ϴ�.");
        }
        endingUIPanel.SetActive(false); // ���� UI ��Ȱ��ȭ
        gameState = GameState.End; // ���� ���¸� End�� ����
    }
}
