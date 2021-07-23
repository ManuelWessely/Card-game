using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class EnemyMono : SerializedMonoBehaviour, IEffectPlayer, IEffectReclever
{

    public TextMeshPro hpText;
    public TextMeshPro actionText;
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

    public void Activate(EnemyMono enemy, Player player)
    {
        selectedEffect.Activate(enemy, player);
    }

    public void DealDamage(int damage)
    {
        hp -= damage;
        UpdateHealth();
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
        hpText.text = $"HP: {hp}";
    }

    public void Activate()
    {
        Activate(this, PlayerMono.instance.player);
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
}
