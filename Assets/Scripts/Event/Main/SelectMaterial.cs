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
        // Set the material
        GameManager.Instance.materialType = (MaterialType)material;
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
