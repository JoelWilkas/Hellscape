using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState;

    [SerializeField] private EnemyStats enemyStats;

    [SerializeField] private AttackState attackState;
    [SerializeField] private IdleState idleState;

    private void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState(this, enemyStats);

        if (nextState != null)
        {
            SwitchToNextState(nextState);
        }
    }


    private void SwitchToNextState(State nextState)
    {
        currentState = nextState;
    }

}
