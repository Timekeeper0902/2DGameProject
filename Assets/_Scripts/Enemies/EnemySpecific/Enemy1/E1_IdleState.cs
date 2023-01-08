using System.Collections;
using System.Collections.Generic;
using Timekeeper.Enemies.Data;
using UnityEngine;

public class E1_IdleState : IdleState
{
    private Enemy1 enemy;

    public E1_IdleState(Entity entity, FiniteStateMachine stateMachine, EnemyAudioData audioData, string animBoolName, EnemyBaseData stateData, Enemy1 enemy) : base(entity, stateMachine, audioData, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        else if (isIdleTimeOver)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
