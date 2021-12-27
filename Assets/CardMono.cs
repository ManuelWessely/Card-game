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
    public Color defaultColor, selectedColor;
    public Image background;
    public CardInformation cardInformation;
    [ShowInInspector]
    public bool Selected { get; private set; }
    [Button]
    public void Init()
    {
        titleText.text = cardInformation.card.title;
        descriptionText.text = cardInformation.card.GetDescription();
        button.onClick.AddListener(() => ToggleSelection());
    }
    public void Select()
    {
        Selected = true;
        background.color = selectedColor;
        PlayerMono.instance.SelectCard(this);
    }
    public void Deselect()
    {
        Selected = false;

        background.color = defaultColor;
        PlayerMono.instance.DeselectCard(this);
    }

    public void Activate(IEffectPlayer player, IEffectReciever enemy)
    {
        //card.Activate(player, enemy);
        Discard();
    }

    public void Discard()
    {
        //CardManager.instance.DiscardCard(this);
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
