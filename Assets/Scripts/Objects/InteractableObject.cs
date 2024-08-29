using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class InteractableObject : MonoBehaviour
{
    public string objectName;
    public virtual void OnClick()
    {
        Debug.Log("Object Clicked");
    }
}
