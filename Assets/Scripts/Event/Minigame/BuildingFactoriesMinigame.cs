using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingFactoriesMinigame : EventData
{
    public static BuildingFactoriesMinigame Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public override void OnEventTrigger()
    {
        base.OnEventTrigger();
        SceneManager.LoadScene("MiniGame2Scene", LoadSceneMode.Additive);
        // Building Factories Minigame
    }
    public override void OnEventEnd()
    {
        base.OnEventEnd();
        // End of Building Factories Minigame
        SceneManager.UnloadSceneAsync("MiniGame2Scene");

        if(GameManager.Instance.TMP <= -120){
            GameManager.Instance.Minigame2Result = MinigameResult.Fail;
        }
    }
}
