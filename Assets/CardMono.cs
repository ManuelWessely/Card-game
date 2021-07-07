using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardMono : MonoBehaviour
{
    public TextMeshProUGUI titleText, descriptionText;
    public Button button;
    public Card card;
    public Color defaultColor, selectedColor;
    public Image background;
    [ShowInInspector]
    public bool Selected { get; private set; }
    [Button]
    public void Init()
    {
        button.onClick.AddListener(() => ToggleSelection());
        titleText.text = card.title;
        descriptionText.text = card.GetDescription();
    }
    public void Select()
    {
        Selected = true;
        background.color = selectedColor;
        PlayerMono.instance.SelectCard(this);
        if (card.selfActivate)
        {
            Activate(PlayerMono.instance.player, null);
        }
    }
    public void Deselect()
    {
        Selected = false;

        background.color = defaultColor;
        PlayerMono.instance.DeselectCard(this);
    }

    public void Activate(IEffectPlayer player, IEffectReclever enemy)
    {
        card.Activate(player, enemy);
        Discard();
    }

    public void Discard()
    {
        CardManager.instance.DiscardCard(this);
    }

    public void ToggleSelection()
    {
        if (Selected)
        {
            Deselect();
        }
        else
        {
            Select();
        }

    }
    
}
