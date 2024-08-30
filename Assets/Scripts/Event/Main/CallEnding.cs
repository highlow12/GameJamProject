using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CallEnding : EventData
{
    public CallEnding()
    {
        eventName = "CallEnding";
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
        SceneManager.LoadScene("Ending", LoadSceneMode.Additive);
    }
    public override void OnEventEnd()
    {
        base.OnEventEnd();
    }
}
