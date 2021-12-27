using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class EnemyMono : SerializedMonoBehaviour, IEffectPlayer, IEffectReciever
{

    public LazyHealthbar healthBar;
    public TextMeshPro actionText;
    public GameObject deathParticles;
    public int maxHp;
    [ReadOnly]
    public int hp;

    public int index;
    public TextMeshProUGUI indexText;
    public EnemyTimelineAgent timelineAgent;

    public Card[] cards;

    private CardInformation cardInformation;
    public bool Activate()
    {
        if (cardInformation==null)
        {
            var rnd = new System.Random();
            cardInformation = new CardInformation();
            cardInformation.card = cards[rnd.Next(cards.Length)];
            cardInformation.effectPlayer = this;
            cardInformation.effectReciever = PlayerMono.instance;
        }

        cardInformation.Activate();
        if (cardInformation.IsPrepared)
        {
            cardInformation = null;
            actionText.text = "";
            return true;

        }
        else
        {
            actionText.text = cardInformation.card.GetDescription();
            return false;
        }
    }


    public void DealDamage(int damage)
    {
        hp -= damage;
        if (hp<=0)
        {
            hp = 0;
            Die();
        }
        UpdateHealth();
    }

    private void Die()
    {
        EnemySpawner.instance.EnemyDied(this);
        Instantiate(deathParticles, transform.position, transform.rotation);
    }

    public void Heal(int amount)
    {
        hp += amount;
        UpdateHealth();
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        healthBar.SetHealth(hp, maxHp);
    }



    private void OnMouseDown()
    {
        print("Clicked");
        PlayerMono.instance.ClickedOnEnemy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
    private void Awake()
    {
        hp = maxHp;
    }
}
