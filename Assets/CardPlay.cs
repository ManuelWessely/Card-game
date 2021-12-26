using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlay 
{
    public Card card;
    public IEffectPlayer effectPlayer;
    public IEffectReciever effectReciever;

    public CardPlay(Card card, IEffectPlayer effectPlayer, IEffectReciever effectReciever)
    {
        this.card = card;
        this.effectPlayer = effectPlayer;
        this.effectReciever = effectReciever;
    }

    public void Activate()
    {
        card.Activate(effectPlayer, effectReciever);
    }
}
