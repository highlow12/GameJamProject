using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Collector : MonoBehaviour
{
    GarbageManager manager;

    public GameObject[] collector;

    void Awake()
    {
        manager = GarbageManager.manager;
    }


    void FixedUpdate()
    {
        if (!manager.hit) { return; }
        //사용자 입력 받기
        if (Input.GetKeyDown("a"))
        {
            manager.hit.transform.position = collector[0].transform.position;
        }
        else if (Input.GetKeyDown("s"))
        {
            manager.hit.transform.position = collector[1].transform.position;
        }
        else if (Input.GetKeyDown("d"))
        {
            manager.hit.transform.position = collector[2].transform.position;
        }
        StartCoroutine("remove",1);
    }

    IEnumerator remove()
    {
        manager.hit.transform.gameObject.SetActive(false);
        yield return null;
    }
}
