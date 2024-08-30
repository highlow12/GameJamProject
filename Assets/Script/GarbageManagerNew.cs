using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum CollectorType
{
    River,
    Ground,
    Sewage
}

public enum GarbageType
{
    Trash,
    Oil
}


public class GarbageManagerNew : MonoBehaviour
{
    public static GarbageManagerNew instance;
    public List<GameObject> garbagePrefabs;
    public Vector3 initialPosition;
    public GameObject[] collector;
    GameObject currentGarbage;
    public int spawnedGarbageCount = 0;
    int garbageCountInRow = 4;
    bool isMoving = false;
    public int garbageCountTotal = 16;
    [SerializeField] private List<GameObject> garbages = new();
    public int currentEnvPoint = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        Init();
    }

    void Update()
    {
        float maxX = -99999;

        foreach (GameObject garbage in garbages)
        {
            if (garbage.transform.position.x > maxX)
            {
                maxX = garbage.transform.position.x;
                currentGarbage = garbage;
            }
        }
        if (isMoving)
        {
            return;
        }
        if (garbageCountTotal == 0 && spawnedGarbageCount == 0)
        {
            MinigameTiemr.Instance.EndTimer();
            SortingTrashes.Instance.OnEventEnd();
            if(currentEnvPoint >= 80){
                GameManager.Instance.Minigame1Result = MinigameResult.Success;
            }else{
                GameManager.Instance.Minigame1Result = MinigameResult.Fail;
            }
            return;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            isMoving = true;
            StartCoroutine(MoveGarbage(currentGarbage, collector[0].transform.position));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            isMoving = true;
            StartCoroutine(MoveGarbage(currentGarbage, collector[1].transform.position));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            isMoving = true;
            StartCoroutine(MoveGarbage(currentGarbage, collector[2].transform.position));
        }
    }

    void Init()
    {
        for (int i = 0; i < garbageCountInRow; i++)
        {
            int garbageIndex = Random.Range(0, garbagePrefabs.Count);
            GameObject instGarbage = Instantiate(
                garbagePrefabs[garbageIndex],
                initialPosition + new Vector3(spawnedGarbageCount * 4, 0, 0),
                Quaternion.identity
            );
            garbages.Add(instGarbage);
            spawnedGarbageCount++;
            garbageCountTotal--;
        }
    }

    void SpawnGarbage()
    {
        if (garbageCountTotal <= 0)
        {
            return;
        }
        foreach (GameObject garbage in garbages)
        {
            garbage.transform.position += new Vector3(4, 0, 0);
        }
        int garbageIndex = Random.Range(0, garbagePrefabs.Count);
        GameObject instGarbage = Instantiate(
            garbagePrefabs[garbageIndex],
            initialPosition,
            Quaternion.identity
        );
        garbages.Add(instGarbage);
        spawnedGarbageCount++;
        garbageCountTotal--;
    }

    public void DespawnGarbage(GameObject garbage)
    {
        isMoving = false;
        garbages.Remove(garbage);
        spawnedGarbageCount--;
        Destroy(garbage);
        StopAllCoroutines();
        SpawnGarbage();
    }

    IEnumerator MoveGarbage(GameObject garbage, Vector3 targetPosition)
    {
        while (Vector2.Distance(garbage.transform.position, targetPosition) > 0.1f && garbage != null)
        {
            garbage.transform.position = Vector2.MoveTowards(
                garbage.transform.position,
                targetPosition,
                20 * Time.deltaTime
            );
            yield return null;
        }
    }
}

    