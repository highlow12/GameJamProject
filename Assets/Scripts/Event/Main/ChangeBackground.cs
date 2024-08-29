using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : EventData
{
    public GameObject background;
    public int backgroundIndex = 0;
    public List<Sprite> backgrounds = new();
    public ChangeBackground()
    {
        eventName = "ChangeBackground";
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
        background.GetComponent<SpriteRenderer>().sprite = backgrounds[backgroundIndex];
        backgroundIndex++;
    }
    public override void OnEventEnd()
    {
        base.OnEventEnd();
    }
}
