using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Heal : Effect
{
    public int amount;
    public async Task Activate(Actor player, Actor enemy)
    {
        player.Heal(amount);
        if (player is PlayerMono)
        {
            ScreenShake.instance.Heal();
            await IconDisplayer.instance.HealPlayer();
        }
    }

    public Task Activate(Actor player, IEffectReciever enemy)
    {
        return Activate(player, enemy as Actor);

    }

    public string GetDescription()
    {
        return $"Heal {amount} HP";
    }
}
