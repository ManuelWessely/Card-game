using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoodieGuyBehavior : EnemyBehavior
{
    public CardInformation GetCardInformation(EnemyMono player)
    {
        var information = new CardInformation();
        information.effectPlayer = player;
        information.card = ScriptableObject.CreateInstance<Card>();

        (Transform left, Transform right)=CharacterPositioning.instance.GetNeighbours(player.transform);
        Transform playerTransform = PlayerMono.instance.transform.parent;
        if (left == playerTransform||right==playerTransform)
        {
            information.card.effects = new Effect[] { new Attack() { damage=10} };
            information.card.prepareTime = 1;
            information.effectReciever = PlayerMono.instance;
        }
        else if(player.hp<player.maxHp)
        {
            information.card.prepareTime = 1;
            information.card.effects = new Effect[] { new Heal() { amount = 10 } };
            information.effectReciever = player;
        }
        else if(CharacterPositioning.instance.IsLeft(player.transform, playerTransform))
        {
            if (left==null)
            {
                var spot =CharacterPositioning.instance.GetLeftSpot(player.transform);
                information.card.effects = new Effect[] { new Move() };
                information.effectReciever = spot.GetComponent<Spot>();
            }
            else
            {
                information.card.effects = new Effect[] { new Wait() };
            }
        }
        else
        {
            if (right == null)
            {
                var spot = CharacterPositioning.instance.GetRightSpot(player.transform);
                information.card.effects = new Effect[] { new Move() };
                information.effectReciever = spot.GetComponent<Spot>();
            }
            else
            {
                information.card.effects = new Effect[] { new Wait() }; 
            }
        }
        return information;
    }
}
