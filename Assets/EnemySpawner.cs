using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    [ShowInInspector, ReadOnly]
    bool[] spotsOccupied;
    [ShowInInspector,ReadOnly]
    private EnemyMono[] enemies;

    public EnemyMono[] spawnableEnemies;
    public static EnemySpawner instance;

    private void Awake()
    {
        instance = this;
        spotsOccupied = new bool[spawnPoints.Length];
        enemies = new EnemyMono[spawnPoints.Length];
    }

    public void PrepareEnemies()
    {
        foreach (var item in enemies)
        {
            if (item)
            {
                item.Prepare();
    
            }
        }
    }

    public async Task ActivateEnemies()
    {
        foreach (var item in enemies)
        {
            if (item)
            {
               await item.Activate();

            }
        }
    }

    [Button]
    public void SpawnEnemies(int number)
    {
        for (int i = 0; i < number; i++)
        {
            if (TryOccupySpot(out int index))
            {
                enemies[index] = SpawnEnemy(index);
            }
            else
            {
               Debug.LogError("Spots Occupied");
            }
        }
    }

    private EnemyMono SpawnEnemy(int index)
    {
        Transform spawnPoint = spawnPoints[index];
        return Instantiate(spawnableEnemies[UnityEngine.Random.Range(0, spawnableEnemies.Length)], spawnPoint.position, spawnPoint.rotation, transform);
    }

    public bool TryOccupySpot(out int index)
    {
        for (int i = 0; i < spotsOccupied.Length; i++)
        {
            if (!spotsOccupied[i])
            {
                index= i;
                spotsOccupied[i] = true;
                return true;
            }
        }
        index= - 1;
        return false;
    }
}
