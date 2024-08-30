using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventData : MonoBehaviour
{
    public string eventName;
    public bool isCallable = true;
    public virtual void OnEventTrigger()
    {
        isCallable = false;
        GameManager.Instance.gameState = GameState.Event;
        Debug.Log("Event Triggered");
    }
    public virtual void OnEventEnd()
    {
        isCallable = true;
        if (GameManager.Instance.gameState == GameState.Event)
        {
            GameManager.Instance.gameState = GameState.Running;
        }
        Debug.Log("Event Ended");
    }

}