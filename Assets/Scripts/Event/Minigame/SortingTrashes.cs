using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SortingTrashes : EventData
{
    public static SortingTrashes Instance;
    public SortingTrashes()
    {
        eventName = "SortingTrashes";
    }
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
        SceneManager.LoadScene("MiniGame1", LoadSceneMode.Additive);
        // Sorting Trashes Minigame
    }
    public override void OnEventEnd()
    {
        base.OnEventEnd();
        SceneManager.UnloadSceneAsync("MiniGame1");
        // End of Sorting Trashes Minigame
    }
}
