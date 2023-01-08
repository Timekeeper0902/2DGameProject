using System.Collections;
using System.Collections.Generic;
using Timekeeper.Enemies.Data;
using UnityEngine;

public class E2_StunState : StunState
{
    private Enemy2 enemy;


    public E2_StunState(Entity entity, FiniteStateMachine stateMachine, EnemyAudioData audioData, string animBoolName, EnemyBaseData stateData, Enemy2 enemy) : base(entity, stateMachine, audioData, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
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

        if (isStunTimeOver)
        {
            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(enemy.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
