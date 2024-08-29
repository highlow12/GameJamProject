using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text timerText;
    void Awake()
    {
        timerText = GetComponent<Text>();
    }
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (timerText)
        {
            timerText.text = GameManager.Instance.gameTime.ToString("F2");
        }
    }
}
