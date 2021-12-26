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
    public Image background, cardRim, icon;
    [ShowInInspector]
    public bool Selected { get; private set; }
    [Button]
    public void Init()
    {
        button.onClick.AddListener(() => ToggleSelection());
        cardRim.color = card.primaryColor;
        descriptionText.color = card.primaryColor;
        titleText.color = card.primaryColor;
        icon.color = card.primaryColor;
        icon.sprite = card.icon;

        Rect rect = card.icon.rect;
        if (rect.height<=rect.width)
        {
            icon.rectTransform.sizeDelta = new Vector2(100, rect.height / rect.width *100);
        }
        else
        {
            icon.rectTransform.sizeDelta = new Vector2(rect.width/rect.height*100, 100);

        }
        titleText.text = card.title;
        descriptionText.text = card.GetDescription();
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
