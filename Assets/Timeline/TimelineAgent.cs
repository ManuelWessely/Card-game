using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineAgent : MonoBehaviour
{
    public RectTransform rectTransform;
    float value;
    public float offset;

    [ShowInInspector, PropertyRange(0,1)]
    public float Value
    {
        get
        {
            return value;
        }
        set
        {
            this.value = value;
            SetPosition(value);
        }
    }

    [Button]
    public void SetPosition(float value)
    {
        var rect = transform.parent.GetComponent<RectTransform>().rect;
        var width = rect.width;

        rectTransform.anchoredPosition = new Vector2(value * width, offset);
    }
}
