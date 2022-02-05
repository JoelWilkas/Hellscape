using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

    public bool isAttacking;
    public AttackState attackState;
    public override State RunCurrentState(StateMachine statemachine, EnemyStats enemyStats )
    {
        if (isAttacking)
        {
            isAttacking = false;
            return attackState;
        } else
        {
            return this;
        }
    }
}
