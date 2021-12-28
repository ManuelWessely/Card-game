using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour, ITransformProvider, IEffectReciever
{
    public Transform GetTransform()
    {
        return transform;
    }
}
