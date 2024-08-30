using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNewsPaper : EventData
{
    public GetNewsPaper()
    {
        eventName = "GetNewsPaper";
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
        Newspaper.Instance.isInteractable = true;
    }
    public override void OnEventEnd()
    {
        base.OnEventEnd();
        Newspaper.Instance.isInteractable = false;
    }
}
