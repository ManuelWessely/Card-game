using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IEffectPlayer, IEffectReclever
{
    public int hp;
    public void DealDamage(int damage)
    {
        hp -= damage;
        gO.UpdateHp();
    }
    public void Heal(int amount)
    {
        hp += amount;
        gO.UpdateHp();
    }
    public PlayerMono gO;
}