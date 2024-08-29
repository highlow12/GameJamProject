using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinigameTiemr : MonoBehaviour
{
    public float timeRemaining;
    public TextMeshProUGUI timeText;
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
}