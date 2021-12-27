using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour
{
    public RectTransform rectTransform;
    public RectTransform timeLineKnobPrefab;
    [ReadOnly]
    public RectTransform[] timelineKnobs;
    public TimelineAgent cursor;
    public List<EnemyTimelineAgent> enemies;

    private int segments;


    public void MoveCursor(int i)
    {
        cursor.SetPosition((float)i / segments);
    }

    public void CreateSegments(int segments)
    {
        this.segments = segments;
        if (timeLineKnobPrefab == null) return;
        if (timelineKnobs!=null)
        {
            foreach (var item in timelineKnobs)
            {
                if (!item)
                {
                    continue;
                }
                if (Application.isPlaying)
                {
                    Destroy(item.gameObject);
                }
                else
                {
                    DestroyImmediate(item.gameObject);
                }
            }
        }
        timelineKnobs = new RectTransform[segments+1];
        for (int i = 0; i < timelineKnobs.Length; i++)
        {
            timelineKnobs[i] = Instantiate(timeLineKnobPrefab, transform);
            var rect = rectTransform.rect;
            var width = rect.width;
            timelineKnobs[i].anchoredPosition = new Vector2((float)i/segments * width, 0);
        }
    }

    public void RemoveAllEnemies()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            Destroy(enemies[i].gameObject);
        }
        enemies = new List<EnemyTimelineAgent>();
    }

    public void Add(EnemyMono enemy, int value)
    {
        EnemyTimelineAgent item = Instantiate(enemy.timelineAgent, transform);
        item.SetPosition((float)value / segments);
        item.numberText.text = enemy.index.ToString();
        enemies.Add(item);

    }
}
