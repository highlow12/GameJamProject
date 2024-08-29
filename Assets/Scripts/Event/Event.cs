using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public List<EventStruct> eventList;
    public abstract class EventStruct
    {
        public string eventName;
        public Vector3 callPos;
        public Vector3 endPos;
        public float eventDuration;

    }

    void Awake()
    {
        eventList = new List<EventStruct>();
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
