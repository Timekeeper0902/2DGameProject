using System.Collections;
using System.Collections.Generic;
using Timekeeper;
using Timekeeper._Panel;
using Timekeeper.Enemies.Data;
using UnityEngine;

public class RangedAttackState : AttackState
{
    protected EnemyBaseData stateData;

    protected GameObject projectile;
    protected Projectile projectileScript;


    public RangedAttackState(Entity entity, FiniteStateMachine stateMachine, BaseAudioData baseAudioData, string animBoolName, Transform attackPosition, EnemyBaseData stateData) : base(entity, stateMachine, baseAudioData, animBoolName, attackPosition)
    {
        this.stateData = stateData;
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        projectile = GameObject.Instantiate(stateData.projectile, attackPosition.position, attackPosition.rotation);
        projectileScript = projectile.GetComponent<Projectile>();
        projectileScript.FireProjectile(stateData.projectileSpeed, stateData.projectileTravelDistance, stateData.projectileDamage);
        AudioManager.Instance.ArrowShootPlay(baseAudioData.e_rangeClip);
    }
}
