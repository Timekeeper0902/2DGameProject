using System.Collections;
using System.Collections.Generic;
using Timekeeper.Enemies.Data;
using UnityEngine;

public class E2_MeleeAttackState : MeleeAttackState
{
    private Enemy2 _enemy;


    public E2_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, EnemyAudioData audioData, string animBoolName, Transform attackPosition, EnemyBaseData stateData, Enemy2 enemy) : base(entity, stateMachine, audioData, animBoolName, attackPosition, stateData)
    {
        _enemy = enemy;
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

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(_enemy.playerDetectedState);
            }else if (!isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(_enemy.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
