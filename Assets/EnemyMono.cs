using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyMono : MonoBehaviour
{

    public TextMeshPro hpText;
    public TextMeshPro actionText;
    public Enemy enemy;
    private void Awake()
    {
        enemy.gO = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        hpText.text = $"HP: {enemy.hp}";
    }
    public void Prepare()
    {
        enemy.Prepare();
        actionText.text = enemy.selectedEffect.GetDescription();
    }

    public void Activate()
    {
        enemy.Activate(enemy, PlayerMono.instance.player);
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
