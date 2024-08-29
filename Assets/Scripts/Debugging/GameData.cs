using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    Text dataText;
    GameManager gameManager;
    void Awake()
    {
        dataText = GetComponent<Text>();
        gameManager = GameManager.Instance;
    }
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (dataText)
        {
            var text = "";
            text += "Game State: " + gameManager.gameState + "\n";
            text += "Money: " + gameManager.money + "\n";
            text += "Env Point: " + gameManager.envPoint + "\n";
            text += "Material Type: " + gameManager.materialType + "\n";
            dataText.text = text;
        }
    }
}
