using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    public GarbageType garbageType;
    GarbageManagerNew garbageManager;
    AudioSource audio;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
        garbageManager = GarbageManagerNew.instance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collector"))
        {
            switch (other.GetComponent<Collector>().collectorType)
            {
                // Need to make singleton alive
                case CollectorType.River:
                    GameManager.Instance.AddEnvPoint(-20);
                    break;
                case CollectorType.Ground:
                    if (garbageType == GarbageType.Trash)
                    {
                        GameManager.Instance.AddEnvPoint(10);
                        garbageManager.currentEnvPoint += 10;
                        GameManager.Instance.AddMoney(-10 * 10000);
                    }
                    else if (garbageType == GarbageType.Oil)
                    {
                        GameManager.Instance.AddEnvPoint(-10);
                        garbageManager.currentEnvPoint -= 10;
                        GameManager.Instance.AddMoney(-10 * 10000);
                    }
                    break;
                case CollectorType.Sewage:
                    if (garbageType == GarbageType.Trash)
                    {
                        GameManager.Instance.AddEnvPoint(-10);
                        garbageManager.currentEnvPoint -= 10;
                        GameManager.Instance.AddMoney(-10 * 10000);
                    }
                    else if (garbageType == GarbageType.Oil)
                    {
                        GameManager.Instance.AddEnvPoint(10);
                        garbageManager.currentEnvPoint += 10;
                        GameManager.Instance.AddMoney(-10 * 10000);
                    }
                    break;
            }

            garbageManager.DespawnGarbage(gameObject);
        }
    }
}