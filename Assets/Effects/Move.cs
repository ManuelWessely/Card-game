using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Move : Effect
{

    public Task Activate(Actor player, IEffectReciever enemy)
    {
        var spot = enemy as Spot;
        Debug.Log("Move");
        CharacterPositioning.instance.TryMoveToSpot(player.GetTransform(), spot.GetTransform());
        return Task.Delay(100);

    }

    public string GetDescription()
    {
        return "Move";
    }
}
