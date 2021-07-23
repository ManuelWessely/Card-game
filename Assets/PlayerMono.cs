using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMono : MonoBehaviour
{
    public static PlayerMono instance;
    public Player player;
    public TextMeshProUGUI hpText;
    private void Awake()
    {
        instance = this;
        player = new Player();
        player.hp = 100;
        player.gO = this;
    }
    private void Start()
    {
        UpdateHp();
    }
    public void UpdateHp()
    {
        hpText.text = $"HP: {player.hp}";
    }
    public  void Heal(int amount)
    {
        player.hp += amount;
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
            selectedCard.Activate(this.player, enemy);
            Destroy(selectedCard.gameObject);
        }
    }
}
