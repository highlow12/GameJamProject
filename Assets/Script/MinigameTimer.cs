using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinigameTiemr : MonoBehaviour
{
    public static MinigameTiemr Instance;
    public float timeRemaining;
    public TextMeshProUGUI timeText;
    void Awake()
    {
        Instance = this;
    }
    void FixedUpdate()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= 0.02f;
        }
        else
        {
            GameManager.Instance.gameState = GameState.Running;
        }
        timeText.text = timeRemaining.ToString("F2");
    }

    public void EndTimer()
    {
        timeRemaining = 0;
    }
}