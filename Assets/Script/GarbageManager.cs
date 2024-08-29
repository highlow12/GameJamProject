using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GarbageManager : MonoBehaviour
{
    public static GarbageManager manager;
    GarbageSpawn spawn;
    public GameObject[] preFabs;
    List<GameObject>[] pooling;

    public RaycastHit2D hit;
    public LayerMask layer;

    void Awake()
    {
        manager = this;
        spawn = GetComponent<GarbageSpawn>();


        pooling = new List<GameObject>[preFabs.Length];

        for(int i = 0; i< preFabs.Length; i++)
        {
            pooling[i] = new List<GameObject>();
        }
    }

    //garbage 위치 확인
    private void FixedUpdate()
    {
        hit = Physics2D.Raycast(spawn.spawnPoint[3].transform.position, Vector2.zero, 0, layer);
    }

    // Garbage 생성 오브젝트 풀링, index 는 garbage 번호 ,garbage 반환
    public GameObject SpawnGarbage(int index)
    {
        GameObject select = null;

        foreach (GameObject garbage in pooling[index])
        {
           if (!garbage.activeSelf)
           {
                select = garbage;
                select.SetActive(true);
                return select;
           }
        }

        if(!select)
        {
           select = Instantiate(preFabs[index]);
           pooling[index].Add(select);
           return select;
        }


        return select;
    }
}
