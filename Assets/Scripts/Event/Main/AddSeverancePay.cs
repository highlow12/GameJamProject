using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSeverancePay : EventData
{
    private bool isGiven = false;
    AudioSource audio;

    public AddSeverancePay()
    {
        eventName = "AddSeverancePay";
    }
    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public override void OnEventTrigger()
    {
        if (isGiven) return;
        base.OnEventTrigger();
        GameManager.Instance.AddMoney(1000 * 10000); // 퇴직금 1000만원 추가
        audio.Play();
        isGiven = true;
    }
    public override void OnEventEnd()
    {
        base.OnEventEnd();
    }
}
