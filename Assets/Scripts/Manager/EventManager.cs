using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public List<EventStruct> eventList;

    // EventStruct
    [System.Serializable]
    public struct EventStruct
    {
        public string eventName;
        public float callTime;
        public float eventDuration;
        // EventObject is the object that has the event abstract class that will be called
        public GameObject eventObject;
    }

    void Awake()
    {

    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        // compare the game time with the call time of the event
        foreach (EventStruct eventStruct in eventList)
        {
            if (GameManager.Instance.gameTime == eventStruct.callTime)
            {
                StartCoroutine(CallEvent(eventStruct));
            }
        }
    }

    IEnumerator CallEvent(EventStruct eventStruct)
    {
        EventData eventData = eventStruct.eventObject.GetComponent<EventData>();
        if (!eventData.isCallable)
        {
            // abort the event if it's not callable
            yield break;
        }
        // Call the event
        // Pause the game time
        eventData.OnEventTrigger();
        // Wait for the event duration
        yield return new WaitForSeconds(eventStruct.eventDuration);
        // Resume the game time
        if (!eventData.isCallable)
        {
            eventData.OnEventEnd();
        }
    }
}
