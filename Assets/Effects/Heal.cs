using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Effect
{
    public int amount;
    public void Activate(IEffectPlayer player, IEffectReclever enemy)
    {
        player.Heal(amount);
    }

    public string GetDescription()
    {
        return $"Heal {amount} HP";
    }
}
