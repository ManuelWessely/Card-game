using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class EnemyMono : SerializedMonoBehaviour, Actor
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
    public EnemyBehavior enemyBehavior;
    private CardInformation cardInformation;
    private bool dead;

    public bool Activate()
    {
        if (dead)
        {
            return true;
        }
        if (cardInformation==null)
        {
            cardInformation = enemyBehavior.GetCardInformation(this);
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
        dead = true;
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

    public Transform GetTransform()
    {
        return transform;
    }
    public IEnumerable<Type> GetBehaviorList()
    {
        var q = typeof(EnemyBehavior).Assembly.GetTypes()
            .Where(x => !x.IsAbstract)
            .Where(x => !x.IsGenericTypeDefinition)
            .Where(x => typeof(EnemyBehavior).IsAssignableFrom(x));
        return q;
    }
}
