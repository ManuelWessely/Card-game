using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(menuName ="Enemy")]
public class Enemy : SerializedScriptableObject, IEffectReclever, IEffectPlayer
{

    public int hp;
    [TypeFilter("GetFilteredTypeList")]
    public Effect[] effects;
    public Effect selectedEffect;
    public EnemyMono gO;

    public void Prepare()
    {
        selectedEffect=SelectEffect();
    }
    public Effect SelectEffect()
    {
        return effects[UnityEngine.Random.Range(0, effects.Length)];
    }
    public IEnumerable<Type> GetFilteredTypeList()
    {
        var q = typeof(Effect).Assembly.GetTypes()
            .Where(x => !x.IsAbstract)
            .Where(x => !x.IsGenericTypeDefinition)
            .Where(x => typeof(Effect).IsAssignableFrom(x));
        return q;
    }

    public void Activate(Enemy enemy, Player player)
    {
        selectedEffect.Activate(enemy, player);
    }

    public void DealDamage(int damage)
    {
        hp -= damage;
        gO.UpdateHealth();
    }

    public void Heal(int amount)
    {
        hp += amount;
        gO.UpdateHealth();
    }
}
