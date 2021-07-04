using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallPool : MonoBehaviour
{
    public static EnemyBallPool Instance;

    public List<GameObject> pooledFireEnemys;
    public List<GameObject> pooledEarthEnemys;
    public List<GameObject> pooledWaterEnemys;

    public GameObject fireEnemysToPool;
    public GameObject earthEnemysToPool;
    public GameObject waterEnemysToPool;

    public int amountToPool;


    // Start is called before the first frame update
    void Awake()
    {
        pooledFireEnemys = new List<GameObject>();
        pooledEarthEnemys = new List<GameObject>();
        pooledWaterEnemys = new List<GameObject>();

        GameObject temp;

        for (int i = 0; i < amountToPool; i++)
        {
            temp = Instantiate(fireEnemysToPool);
            temp.transform.SetParent(this.transform);
            pooledFireEnemys.Add(temp);

            temp = Instantiate(earthEnemysToPool);
            temp.transform.SetParent(this.transform);
            pooledEarthEnemys.Add(temp);

            temp = Instantiate(waterEnemysToPool);
            temp.SetActive(false);
            temp.transform.SetParent(this.transform);
            pooledWaterEnemys.Add(temp);
        }
    }

    private void Start()
    {
        foreach (var pooledFireEnemy in pooledFireEnemys)
        {
            pooledFireEnemy.SetActive(false);
        }

        foreach (var pooledEarthEnemy in pooledEarthEnemys)
        {
            pooledEarthEnemy.SetActive(false);
        }

        foreach (var pooledWaterEnemy in pooledWaterEnemys)
        {
            pooledWaterEnemy.SetActive(false);
        }
    }

    public GameObject GetRandomEnemy(int levelEnemy)
    {
        int randomIndex = Random.Range(1, 4);

        switch (randomIndex)
        {
            case 1:
                return GetPooledFireEnemy(levelEnemy);
            case 2:
                return GetPooledEarthEnemy(levelEnemy);
            case 3:
                return GetPooledWaterEnemy(levelEnemy);
            default:
                return GetRandomEnemy(levelEnemy);
        }
    }

    public GameObject GetPooledFireEnemy(int levelEnemy)
    {
        for (int i = 0; i < pooledFireEnemys.Count; i++)
        {
            if (pooledFireEnemys[i].activeInHierarchy == false)
            {
                pooledFireEnemys[i].GetComponent<Ball>().SetLevel(levelEnemy);
                pooledFireEnemys[i].SetActive(true);
                return pooledFireEnemys[i];
            }
        }

        return null;
    }

    public GameObject GetPooledEarthEnemy(int levelEnemy)
    {
        for (int i = 0; i < pooledEarthEnemys.Count; i++)
        {
            if (!pooledEarthEnemys[i].activeInHierarchy)
            {
                pooledEarthEnemys[i].GetComponent<Ball>().SetLevel(levelEnemy);
                pooledEarthEnemys[i].SetActive(true);
                return pooledEarthEnemys[i];
            }
        }

        return null;
    }

    public GameObject GetPooledWaterEnemy(int levelEnemy)
    {
        for (int i = 0; i < pooledWaterEnemys.Count; i++)
        {
            if (!pooledWaterEnemys[i].activeInHierarchy)
            {
                pooledWaterEnemys[i].GetComponent<Ball>().SetLevel(levelEnemy);
                pooledWaterEnemys[i].SetActive(true);
                return pooledWaterEnemys[i];
            }
        }

        return null;
    }

    public int GetCountEnemyActive()
    {
        int countEnemy = 0;

        foreach (var pooledFireEnemy in pooledFireEnemys)
        {
            if (pooledFireEnemy.activeInHierarchy)
            {
                countEnemy++;
            }
        }

        foreach (var pooledEarthEnemy in pooledEarthEnemys)
        {
            if (pooledEarthEnemy.activeInHierarchy)
            {
                countEnemy++;
            }
        }

        foreach (var pooledWaterEnemy in pooledWaterEnemys)
        {
            if (pooledWaterEnemy.activeInHierarchy)
            {
                countEnemy++;
            }
        }

        return countEnemy;
    }

    public GameObject[] GetAllEnemyBall()
    {
        return transform.GetComponentsInChildren<GameObject>();
    }
}
