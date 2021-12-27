using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[Serializable]
public class CardInformation
{
    public Card card;
    public IEffectPlayer effectPlayer;
    public IEffectReciever effectReciever;
    private int elapsedPrepareTime;
    public bool IsPrepared
    {
        get;
        private set;
    }
    public void Prepare()
    {

    }
    public void Activate()
    {
        if (elapsedPrepareTime<card.prepareTime)
        {
            elapsedPrepareTime++;
            return;
        }
        IsPrepared = true;

        card.Activate(effectPlayer, effectReciever);
    }
    //Modifiers
}
