using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemyBehavior 
{
    CardInformation GetCardInformation(EnemyMono player);
}
