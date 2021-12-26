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

    private int segments;
    [ShowInInspector,MinValue(1)]
    public int Segments
    {
        get
        {
            return segments;
        }
        set
        {
            segments = value;
            CreateSegments(segments);
        }
    }

    public void MoveCursor(int i)
    {
        cursor.SetPosition((float)i / segments);
    }

    public void CreateSegments(int segments)
    {
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
    
}
