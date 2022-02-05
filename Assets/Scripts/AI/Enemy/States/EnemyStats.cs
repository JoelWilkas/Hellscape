using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "data", menuName = "Ai/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public float moveSpeed = 5;
    public float health = 10;

    public AnimationCurve movementCurve;
}
