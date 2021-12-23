using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMono : MonoBehaviour, IEffectPlayer, IEffectReciever
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
            selectedCard.Activate(this, enemy);
            Destroy(selectedCard.gameObject);
        }
    }



    public Vector3 GetPosition()
    {
        return Vector3.zero;
    }
}
