using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.VFX;

public class CardManager : SerializedMonoBehaviour
{
    public Dictionary<string, CardMono> cards;
    public List<string> deck = new List<string>();
    public static CardManager instance;
    public Stack<string> drawPile = new Stack<string>(), discardPile = new Stack<string>();
    public List<CardMono> activeCards;
    public RectTransform contentRect;

    public void Init()
    {
        instance = this;
        foreach (var item in deck)
        {
            drawPile.Push(item);
        }
        ShuffleDrawPile();
    }
    private void Awake()
    {
        Init();
    }
    [Button]
    public void Draw(int number)
    {
        for (int i = 0; i < number; i++)
        {
            if (drawPile.Count == 0)
            {
                Reshuffle();
            }

            var cardPrefab = cards[ drawPile.Pop()];
            var cardMono = Instantiate(cardPrefab, contentRect);
            cardMono.Init();
            activeCards.Add(cardMono);
        }

    }
    public void Reshuffle()
    {
        while (discardPile.Count > 0)
        {
            drawPile.Push(discardPile.Pop());
        }
        ShuffleDrawPile();
    }
    public void DiscardCard(CardMono cardMono)
    {
        activeCards.Remove(cardMono);
        discardPile.Push(cardMono.cardInformation.card.title);
        Destroy(cardMono.gameObject);

    }
    [Button]
    public void DiscardAll()
    {
        while (activeCards.Count > 0)
        {
            DiscardCard(activeCards[0]);
        }

    }
    public void ShuffleDrawPile()
    {
        System.Random rnd = new System.Random();
        var drawArray = drawPile.ToArray().OrderBy(x => rnd.Next());
        drawPile = new Stack<string>();
        foreach (var item in drawArray)
        {
            drawPile.Push(item);
        }
    }

}
