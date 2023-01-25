using System.Collections;
using System.Collections.Generic;
using Timekeeper._Panel;
using Timekeeper.Enemies.Data;
using UnityEngine;

public class E1_DeadState : DeadState
{
    private Enemy1 enemy;


    public E1_DeadState(Entity entity, FiniteStateMachine stateMachine, BaseAudioData baseAudioData, string animBoolName, EnemyBaseData stateData, Enemy1 enemy) : base(entity, stateMachine, baseAudioData, animBoolName, stateData)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
