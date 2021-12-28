using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Wait : Effect
{
    public Task Activate(Actor player, IEffectReciever enemy)
    {
        return Task.Delay(100);
    }

    public string GetDescription()
    {
        return "Wait";
    }
}
