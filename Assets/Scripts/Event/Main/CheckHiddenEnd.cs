using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHiddenEnd : EventData
{
    public static CheckHiddenEnd Instance;
    public CheckHiddenEnd()
    {
        eventName = "CheckHiddenEnd";
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
        if (GameManager.Instance.hiddenEnd)
        {
            GameManager.Instance.hiddenEnd = false;
            GameManager.Instance.ShowEndingUI();
        }
        else
        {
            OnEventEnd();
        }
    }
    public override void OnEventEnd()
    {
        base.OnEventEnd();
    }
}
