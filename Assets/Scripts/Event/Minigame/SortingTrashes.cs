using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SortingTrashes : EventData
{
    public SortingTrashes()
    {
        eventName = "SortingTrashes";
    }
    void Awake()
    {

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
        // End of Sorting Trashes Minigame
    }
}
