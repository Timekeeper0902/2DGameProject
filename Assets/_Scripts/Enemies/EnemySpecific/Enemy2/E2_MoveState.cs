﻿using System.Collections;
using System.Collections.Generic;
using Timekeeper._Panel;
using Timekeeper.Enemies.Data;
using UnityEngine;

public class E2_MoveState : MoveState
{
    private Enemy2 enemy;


    public E2_MoveState(Entity entity, FiniteStateMachine stateMachine, BaseAudioData baseAudioData, string animBoolName, EnemyBaseData stateData, Enemy2 enemy) : base(entity, stateMachine, baseAudioData, animBoolName, stateData)
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

        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        else if(isDetectingWall || !isDetectingLedge)
        {
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
