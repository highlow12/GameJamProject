using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    Start,
    Running,
    Event,
    Select,
    End
}

public class GameManager : Singleton<GameManager>
{
    public float gameTime;
    public Action startAction;
    public Action runningAction;
    public GameState gameState = GameState.Select;
    private int money = 0;
    private int envPoint { get; set; }

    new void Awake()
    {
        runningAction += UpdateTime;
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
                break;
            case GameState.Event:
                break;
            case GameState.Select:
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

        }
        else if (envPoint > nomalEndingPoint)
        {

        }
        else if (envPoint > badEndingPoint)
        {

        }
    }

    void UpdateTime()
    {
        gameTime += 0.02f;
        gameTime = (float)Math.Round(gameTime, 2);
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }
}
