using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName ="Card")]
public class Card : SerializedScriptableObject
{

    public string title;
    [ShowInInspector]
    [TypeFilter("GetFilteredTypeList")]
    public Effect[] effects;
    public Color primaryColor;
    public Sprite icon;

    public string GetDescription()
    {
        string s = "";
        for (int i = 0; i < effects.Length; i++)
        {
            s += effects[i].GetDescription()+"\n";
        }
        return s;
    }
    public void Activate(IEffectPlayer player, IEffectReciever enemy)
    {
        foreach (var item in effects)
        {
            item.Activate(player, enemy);
        }
    }
    public IEnumerable<Type> GetFilteredTypeList()
    {
        var q = typeof(Effect).Assembly.GetTypes()
            .Where(x => !x.IsAbstract)
            .Where(x => !x.IsGenericTypeDefinition)
            .Where(x => typeof(Effect).IsAssignableFrom(x));
        return q;
    }
}
