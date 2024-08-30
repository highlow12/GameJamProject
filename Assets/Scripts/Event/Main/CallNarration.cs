using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CallNarration : EventData
{
    [SerializeField] private GameObject narrationUI;
    [SerializeField] private TextMeshProUGUI narrationText;
    [SerializeField] private List<string> narrations = new();
    private int narrationIndex = 0;
    public CallNarration()
    {
        eventName = "CallNarration";
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
        narrationUI.SetActive(true);
        string narration = narrations[narrationIndex];
        narration.Replace("\\n", "\n");
        narrationText.text = narration;
        narrationIndex++;
    }
    public override void OnEventEnd()
    {
        base.OnEventEnd();
        narrationUI.SetActive(false);
    }
}
