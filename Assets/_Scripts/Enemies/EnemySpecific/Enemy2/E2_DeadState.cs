using System.Collections;
using System.Collections.Generic;
using Timekeeper.Enemies.EnemySpecific.Enemy1;
using UnityEngine;

public class E2_DeadState : DeadState
{
    private Enemy2 enemy;

    public E2_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, EnemyBaseData stateData, Enemy2 enemy) : base(entity, stateMachine, animBoolName, stateData)
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
    
