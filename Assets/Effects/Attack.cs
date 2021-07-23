using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Effect
{
    public int damage;
    public void Activate(IEffectPlayer player, IEffectReclever enemy)
    {
        enemy.DealDamage(damage);
        if (enemy is Player)
        {
            ScreenShake.instance.EnemyAttack();
            IconDisplayer.instance.EnemyAttack();
        }
        else if (enemy is EnemyMono)
        {
            ScreenShake.instance.PlayerAttack();
            IconDisplayer.instance.PlayerAttack();
        }
    }

    public string GetDescription()
    {
        return $"Deal {damage} Damage";
    }
}
