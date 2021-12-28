using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOpponent :IEffectReciever
{
    void DealDamage(int damage);

}
