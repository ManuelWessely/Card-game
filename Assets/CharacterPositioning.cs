using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterPositioning : MonoBehaviour
{
    public Transform[] spots;
    [ReadOnly]
    public Transform[] occupiedSpots;
    public static CharacterPositioning instance;
    [Button]
    private void Awake()
    {
        instance = this;
        occupiedSpots = new Transform[spots.Length];
    }

    [Button]
    public bool TryMoveToSpot(Transform character, int index)
    {
        if (occupiedSpots[index]!=null)
        {
            return false;
        }
        int prevIndex = Array.FindIndex(occupiedSpots, x => x == character);
        if (prevIndex != -1)
        {
            occupiedSpots[prevIndex] = null;
        }
        character.position = spots[index].position;
        occupiedSpots[index] = character;
        return true;

    }
    [Button]
    public bool TryMoveToSpot(Transform character, Transform spot)
    {
        int spotIndex = Array.FindIndex(spots, x => x == spot);
        if (spotIndex!=-1)
        {
            return TryMoveToSpot(character, spotIndex);
        }
        int occupiedSpotIndex = Array.FindIndex(occupiedSpots, x => x == spot);
        if (occupiedSpotIndex != -1)
        {
            return TryMoveToSpot(character, occupiedSpotIndex);
        }
        return false;
    }

    public Transform GetLeftSpot(Transform character)
    {
        int index = Array.FindIndex(occupiedSpots, x => x == character);
        if (index == 0)
        {
            return null;
        }
        return spots[index - 1];
    }
    public Transform GetRightSpot(Transform character)
    {
        int index = Array.FindIndex(occupiedSpots, x => x == character);
        if (index == occupiedSpots.Length-1)
        {
            return null;
        }
        return spots[index + 1];
    }
    public (Transform left, Transform right) GetNeighbours(Transform center)
    {
        int index = Array.FindIndex(occupiedSpots, x => x == center);
        if (index==0)
        {
            return (null, occupiedSpots[1]);
        }
        if (index == occupiedSpots.Length-1)
        {
            return (occupiedSpots[index-1],null);
        }
        return (occupiedSpots[index - 1], occupiedSpots[index + 1]);
    }
    public bool IsLeft(Transform self, Transform canditate)
    {
        int selfIndex = Array.FindIndex(occupiedSpots, x => x == self);
        int canditateIndex = Array.FindIndex(occupiedSpots, x => x == canditate);
        return canditateIndex < selfIndex;

    }
    public void RandomlyPlace(List<Transform> transforms)
    {
        occupiedSpots = new Transform[spots.Length];
        var values = Enumerable.Range(0, occupiedSpots.Length).ToList();
        var rnd = new System.Random();

        for (int i = 0; i < transforms.Count; i++)
        {
            int index = rnd.Next(values.Count);
            var value = values[index];
            occupiedSpots[value] = transforms[i];
            occupiedSpots[value].position = spots[value].position;
            values.RemoveAt(index);
        }
    }
}
