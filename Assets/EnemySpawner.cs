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
    public EnemyMono[] enemies;

    public EnemyMono[] spawnableEnemies;
    public static EnemySpawner instance;

    private void Awake()
    {
        instance = this;
        spotsOccupied = new bool[spawnPoints.Length];
        enemies = new EnemyMono[spawnPoints.Length];
    }



    [Button]
    public void SpawnEnemies(int number)
    {
        for (int i = 0; i < number; i++)
        {
            if (TryOccupySpot(out int index))
            {
                enemies[index] = SpawnEnemy(index);
                enemies[index].index = index;
                enemies[index].indexText.text = index.ToString();
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

    public void EnemyDied(EnemyMono enemyMono)
    {
        var index=Array.FindIndex(enemies, x => x == enemyMono);
        Timeline.instance.RemoveEnemy(enemyMono);
        FreeSpot(index);
        Destroy(enemyMono.gameObject);
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
    public void FreeSpot(int index)
    {
        spotsOccupied[index] = false;
    }
}
