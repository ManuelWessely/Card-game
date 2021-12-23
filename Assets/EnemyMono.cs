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
    [ShowInInspector]
    [TypeFilter("GetFilteredTypeList")]
    public Effect[] effects;
    public Effect selectedEffect;

    public void Prepare()
    {
        selectedEffect = SelectEffect();
        actionText.text = selectedEffect.GetDescription();

    }
    public Effect SelectEffect()
    {
        return effects[UnityEngine.Random.Range(0, effects.Length)];
    }
    public IEnumerable<Type> GetFilteredTypeList()
    {
        var q = typeof(Effect).Assembly.GetTypes()
            .Where(x => !x.IsAbstract)
            .Where(x => !x.IsGenericTypeDefinition)
            .Where(x => typeof(Effect).IsAssignableFrom(x));
        return q;
    }

    public Task Activate(EnemyMono enemy, PlayerMono player)
    {
        return selectedEffect.Activate(enemy, player);
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

    public Task Activate()
    {
        return Activate(this, PlayerMono.instance);
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
