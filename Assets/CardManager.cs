using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CardManager : MonoBehaviour
{
    public List<Card> deck;
    [ShowInInspector]
    public Stack<Card> drawPile=new Stack<Card>(), discardPile = new Stack<Card>();
    public List<CardMono> activeCards;
    public CardMono cardPrefab;
    public RectTransform contentRect;
    public static CardManager instance;
    private void Awake()
    {
        Init();
    }
    private void Start()
    {
    }
    [Button]
    public void Draw(int number)
    {
        for (int i = 0; i < number; i++)
        {
            if (drawPile.Count==0)
            {
                Reshuffle();
            }
            var cardMono = Instantiate(cardPrefab, contentRect);
            cardMono.card = drawPile.Pop();
            cardMono.Init();
            activeCards.Add(cardMono);
        }

    }
    public void Init()
    {
        instance = this;
        foreach (var item in deck)
        {
            drawPile.Push(item);
        }
    }
    public void DiscardCard(CardMono cardMono)
    {
        activeCards.Remove(cardMono);
        discardPile.Push(cardMono.card);
        Destroy(cardMono.gameObject);

    }
    public void Reshuffle()
    {
        while (discardPile.Count>0)
        {
            drawPile.Push(discardPile.Pop());
        }
    }
    [Button]
    public void DiscardAll()
    {
        while (activeCards.Count>0)
        {
            DiscardCard(activeCards[0]);
        }
        
    }
}
