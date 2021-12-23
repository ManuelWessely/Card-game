using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface Effect 
{
    string GetDescription();
    Task Activate(IEffectPlayer player, IEffectReclever enemy);
}
