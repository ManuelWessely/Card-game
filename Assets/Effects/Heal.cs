using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Heal : Effect
{
    public int amount;
    public async Task Activate(IEffectPlayer player, IEffectReclever enemy)
    {
        player.Heal(amount);
    }

    public string GetDescription()
    {
        return $"Heal {amount} HP";
    }
}
