using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMono : MonoBehaviour, Actor
{
    public static PlayerMono instance;
    public int hp, maxHp;
    public LazyHealthbar healthBar;
    private void Awake()
    {
        instance = this;
        hp = 100;
        maxHp = 100;
    }
    private void Start()
    {
        UpdateHp();
    }
    public void UpdateHp()
    {
        healthBar.SetHealth(hp, maxHp);
    }
    public void Heal(int amount)
    {

        hp += amount;
        if (hp>maxHp)
        {
            hp = maxHp;
        }
        UpdateHp();
    }
    public void DealDamage(int damage)
    {
        hp -= damage;

        if (hp<=0)
        {
            hp = 0;
            print("Player Died");
        }
        UpdateHp();
    }
    public CardMono selectedCard;
    public void SelectCard(CardMono card)
    {
        if (selectedCard)
        {
            selectedCard.Deselect();
        }
        selectedCard = card;

    }
    public void DeselectCard(CardMono card)
    {
        selectedCard = null;
    }
    public void ClickedOnEnemy(EnemyMono enemy)
    {
        if (selectedCard)
        {
            selectedCard.cardInformation.effectPlayer = this;
            selectedCard.cardInformation.effectReciever = enemy;
            RoundManager.instance.playerCard=selectedCard.cardInformation;
            CardManager.instance.DiscardCard(selectedCard);
        }
    }
    private void OnMouseDown()
    {
        if (selectedCard)
        {
            selectedCard.cardInformation.effectPlayer = this;
            selectedCard.cardInformation.effectReciever = this;
            RoundManager.instance.playerCard = selectedCard.cardInformation;
            CardManager.instance.DiscardCard(selectedCard);

        }
    }



    public Vector3 GetPosition()
    {
        return Vector3.zero;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
