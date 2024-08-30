using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNewsPaper : EventData
{
    AudioSource _audio;
    public GetNewsPaper()
    {
        eventName = "GetNewsPaper";
    }
    void Awake()
    {
        _audio = GetComponent<AudioSource>();
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
    }
    public override void OnEventEnd()
    {
        base.OnEventEnd();
        _audio.Play();
    }
}
