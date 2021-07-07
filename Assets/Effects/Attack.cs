using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Effect
{
    public int damage;
    public void Activate(IEffectPlayer player, IEffectReclever enemy)
    {
        enemy.DealDamage(damage);
    }

    public string GetDescription()
    {
        return $"Deal {damage} Damage";
    }
}
