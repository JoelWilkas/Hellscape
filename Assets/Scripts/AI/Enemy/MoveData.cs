using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "data", menuName = "Ai/MoveData")]

public class MoveData : ScriptableObject
{
    public float moveSpeed = 5f;
    public float detectionRange = 4f;
    public float maxIdleTime;
    public float minIdleTime;

    public AnimationCurve movementCurve;
}
