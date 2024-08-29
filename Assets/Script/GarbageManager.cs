using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GarbageManager : MonoBehaviour
{
    GarbageSpawn spawn;

    public GameObject[] preFabs;
    List<GameObject>[] pooling;
    public GameObject[] collector;

    public RaycastHit2D hit;
    public RaycastHit2D firstHit;
    public LayerMask layer;

    void Awake()
    {
        spawn = GetComponent<GarbageSpawn>();


        pooling = new List<GameObject>[preFabs.Length];

        for(int i = 0; i< pooling.Length; i++)
        {
            pooling[i] = new List<GameObject>();
        }
    }

    //garbage 위치 확인
    private void FixedUpdate()
    {

        hit = Physics2D.Raycast(spawn.spawnPoint[3].transform.position, Vector2.zero, 0, layer);
        if (!hit)
        {
            spawn.isWaiting = true;
        }
        else
        {
            spawn.isWaiting = false;
        }
    }

    private void Update()
    {
        if (hit && hit.transform.gameObject.activeSelf)
        {
            RaycastHit2D garbage = hit;
            //사용자 입력 받기
            if (Input.GetKeyDown(KeyCode.A))
            {
                DeleteGarbage(0);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                DeleteGarbage(1);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                DeleteGarbage(2);
            }
        }
    }
    

    void DeleteGarbage(int index)
    {
        RaycastHit2D garbage = hit;
        garbage.transform.position = collector[index].transform.position;
        garbage.transform.parent = null;
        garbage.transform.gameObject.SetActive(false);
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
                break;
           }
        }

        if(!select)
        {
           select = Instantiate(preFabs[index]);
           pooling[index].Add(select);
        }


        return select;
    }
}
