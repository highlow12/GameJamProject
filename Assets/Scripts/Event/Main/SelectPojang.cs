using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPojang : EventData
{
    public SelectPojang()
    {
        eventName = "SelectPojang";
    }
    [SerializeField]
    private GameObject selectUI;
    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void SetPojang(int pojangType)
    {
        GameManager manager = GameManager.Instance;
        // Set the material
        manager.pojangType = (PojangType)pojangType;
        switch ((PojangType)pojangType)
        {
            case PojangType.Paper:
                manager.AddEnvPoint(20);
                break;
            case PojangType.Aircap:
                manager.AddEnvPoint(-10);
                break;
            case PojangType.Vinil:
                manager.AddEnvPoint(-20);
                break;
        }
        OnEventEnd();
    }

    public override void OnEventTrigger()
    {
        base.OnEventTrigger();
        // Show the select UI
        selectUI.SetActive(true);
    }
    public override void OnEventEnd()
    {
        base.OnEventEnd();
        // Hide the select UI
        selectUI.SetActive(false);
    }
}
