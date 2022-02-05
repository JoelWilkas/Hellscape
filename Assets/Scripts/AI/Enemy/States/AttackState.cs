using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{

    public bool hitPlayer;
    public IdleState idleState;

    public override State RunCurrentState(StateMachine statemachine, EnemyStats enemyStats)
    {
        if(hitPlayer)
        {
            hitPlayer = false;
            return idleState;
        } else
        {
            return this;
        }
    }
}