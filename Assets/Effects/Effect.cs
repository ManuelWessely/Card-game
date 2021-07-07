using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Effect 
{
    string GetDescription();
    void Activate(IEffectPlayer player, IEffectReclever enemy);
}
