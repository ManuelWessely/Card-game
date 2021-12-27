using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Heal : Effect
{
    public int amount;
    public async Task Activate(IEffectPlayer player, IEffectReciever enemy)
    {
        player.Heal(amount);
        if (player is PlayerMono)
        {
            Debug.Log("Attack");
            ScreenShake.instance.Heal();
            await IconDisplayer.instance.HealPlayer();
        }
    }

    public string GetDescription()
    {
        return $"Heal {amount} HP";
    }
}
