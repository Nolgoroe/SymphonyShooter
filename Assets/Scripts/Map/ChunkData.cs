using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Directions
{
    Right,
    Left,
    Up,
    Down,
    RightUp,
    RightDown,
    LeftUp,
    LeftDown
}

[System.Serializable]
public class DirectionToPositionCombo
{
    public Directions direction;
    public Transform pointPosition;
}

public class ChunkData : MonoBehaviour
{
    [SerializeField] private List<DirectionToPositionCombo> directionsToPositionsArray;
    [SerializeField] private Transform pointsParent;

    private void Start()
    {
        directionsToPositionsArray.Clear();
        foreach (Directions direction in System.Enum.GetValues(typeof(Directions)))
        {
            DirectionToPositionCombo combo = new DirectionToPositionCombo();
            combo.direction = direction;
            combo.pointPosition = pointsParent.Find(direction.ToString());
            directionsToPositionsArray.Add(combo);
        }
    }
    public DirectionToPositionCombo ReturnDirectionToPosition(Directions direction)
    {
        return directionsToPositionsArray[(int)direction];
    }
}
