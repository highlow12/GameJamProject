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

    //garbage ��ġ Ȯ��
    private void FixedUpdate()
    {
        hit = Physics2D.Raycast(spawn.spawnPoint[3].transform.position, Vector2.zero, 0, layer);
    }

    // Garbage ���� ������Ʈ Ǯ��, index �� garbage ��ȣ ,garbage ��ȯ
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
