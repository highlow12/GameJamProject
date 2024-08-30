using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSeverancePay : EventData
{
    private bool isGiven = false;
    [SerializeField]
    private AudioSource _audio;

    public AddSeverancePay()
    {
        eventName = "AddSeverancePay";
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
        if (isGiven) return;
        base.OnEventTrigger();
        GameManager.Instance.AddMoney(1000 * 10000); // 퇴직금 1000만원 추가
        isGiven = true;
    }
    public override void OnEventEnd()
    {
        base.OnEventEnd();
    }
}
