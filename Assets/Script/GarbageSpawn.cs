using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSpawn : MonoBehaviour
{
    public GameObject[] spawnPoint;
    GarbageManager manager;
    GameObject garbage;


    private void Awake()
    {
        manager = GetComponent<GarbageManager>();
    }

    private void Start()
    {
        Init();
    }

    void FixedUpdate()
    {
        if (!manager.hit)
        {
            MoveGarbage();
        }
    }

    void Init()
    {
        // Ã¹ Garbage ¹èÄ¡
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            garbage = Instantiate(manager.preFabs[Random.Range(0, manager.preFabs.Length)], spawnPoint[i].transform);
            garbage.transform.position = spawnPoint[i].transform.position;
        }
    }


    // agsd
    void MoveGarbage()
    {
        for (int i = spawnPoint.Length - 2; i >= 0; i--)
        {
            spawnPoint[i].transform.GetChild(0).transform.position = spawnPoint[i + 1].transform.position;
            spawnPoint[i].transform.GetChild(0).parent = spawnPoint[i + 1].transform;
        }
        garbage = manager.SpawnGarbage(Random.Range(0, manager.preFabs.Length));
        garbage.transform.position = spawnPoint[0].transform.position;
        garbage.transform.parent = spawnPoint[0].transform;
    }
}
