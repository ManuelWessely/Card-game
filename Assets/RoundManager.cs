using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public int segments;
    public Timeline timeline;
    [NonSerialized]
    public CardInformation playerCard=null;
    public static RoundManager instance;
    Dictionary<int, EnemyMono> enemyTurns = new Dictionary<int, EnemyMono>();
    List<EnemyMono> workingEnemies = new List<EnemyMono>();
    private int currentSegment;
    private void Awake()
    {
        instance = this;
        playerCard = null;
    }
    void Start()
    {

        timeline.CreateSegments(6);
        EnemySpawner.instance.SpawnEnemies(3);
        StartCoroutine(GameCoroutine());
    }


   
    IEnumerator GameCoroutine()
    {
        while (true)
        {
            CardManager.instance.Draw(4);
            AssignEnemies();
            yield return RoundCoroutine();
            CardManager.instance.DiscardAll();
        }
    }

    private void AssignEnemies()
    {
        workingEnemies = new List<EnemyMono>();
        enemyTurns = new Dictionary<int, EnemyMono>();
        timeline.RemoveAllEnemies();
        var rand = new System.Random();
        var values = Enumerable.Range(0, segments-1).ToList();
        EnemyMono[] enemies = EnemySpawner.instance.enemies;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null) continue;
            enemies[i].actionText.text = "";
            int index = rand.Next(values.Count);
            int value = values[index];
            enemyTurns.Add(value, enemies[i]);

            timeline.Add(enemies[i], value);
            values.RemoveAt(index);
        }
    }

    IEnumerator RoundCoroutine()
    {
        while (currentSegment<segments)
        {
            if (playerCard != null)
            {
                playerCard.Activate();
                if (playerCard.IsPrepared)
                {

                    playerCard = null;
                }
                else
                {
                    IconDisplayer.instance.ActivateSandClock();
                }
                if (enemyTurns.ContainsKey(currentSegment))
                {
                    workingEnemies.Add(enemyTurns[currentSegment]);
                }
                List<EnemyMono> enemiesToRemove = new List<EnemyMono>();
                foreach (var item in workingEnemies)
                {
                    var activated=item.Activate();
                    if (activated)
                    {
                        enemiesToRemove.Add(item);
                    }
                }
                foreach (var item in enemiesToRemove)
                {
                    workingEnemies.Remove(item);
                }
                currentSegment++;
                timeline.MoveCursor(currentSegment);
                yield return new WaitForSeconds(1);
                IconDisplayer.instance.HideAll();
            }
            else
            {
                yield return null;
            }
        }
        currentSegment = 0;
        timeline.MoveCursor(currentSegment);

    }
}
