using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMaterial : EventData
{
    public SelectMaterial()
    {
        eventName = "SelectMaterial";
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

    public void SetMaterial(int material)
    {
        GameManager manager = GameManager.Instance;
        // Set the material
        manager.materialType = (MaterialType)material;
        switch ((MaterialType)material)
        {
            case MaterialType.Cotton:
                manager.AddEnvPoint(10);
                break;
            case MaterialType.Leather:
                manager.AddEnvPoint(0);
                break;
            case MaterialType.Tencel:
                manager.AddEnvPoint(20);
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
