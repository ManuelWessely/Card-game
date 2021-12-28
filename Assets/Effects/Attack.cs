using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Attack : Effect
{
    public int damage;
    public async Task Activate(Actor player, Actor enemy)
    {
        enemy.DealDamage(damage);
        if (enemy is PlayerMono)
        {
            Debug.Log("Attack");
            ScreenShake.instance.EnemyAttack();
            await IconDisplayer.instance.EnemyAttack(player.GetPosition());
        }
        else if (enemy is EnemyMono)
        {
            ScreenShake.instance.PlayerAttack();
            IconDisplayer.instance.PlayerAttack();
        }
    }

    public Task Activate(Actor player, IEffectReciever enemy)
    {
        return Activate(player, enemy as Actor);
    }

    public string GetDescription()
    {
        return $"Deal {damage} Damage";
    }
}
