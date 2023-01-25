using System.Collections;
using System.Collections.Generic;
using Timekeeper._Panel;
using Timekeeper.CoreSystem;
using Timekeeper.Enemies.Data;
using UnityEngine;

public class AttackState : State {
	public AttackState(Entity entity, FiniteStateMachine stateMachine, BaseAudioData baseAudioData, string animBoolName, Transform attackPosition) : base(entity, stateMachine, baseAudioData, animBoolName)
	{
		this.attackPosition = attackPosition;
	}

	private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
	private Movement movement;

	protected Transform attackPosition;

	protected bool isAnimationFinished;
	protected bool isPlayerInMinAgroRange;

	

	public override void DoChecks() {
		base.DoChecks();

		isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
	}

	public override void Enter() {
		base.Enter();

		entity.atsm.attackState = this;
		isAnimationFinished = false;
		Movement?.SetVelocityX(0f);
	}

	public override void Exit() {
		base.Exit();
	}

	public override void LogicUpdate() {
		base.LogicUpdate();
		Movement?.SetVelocityX(0f);
	}

	public override void PhysicsUpdate() {
		base.PhysicsUpdate();
	}

	public virtual void TriggerAttack() {

	}

	public virtual void FinishAttack() {
		isAnimationFinished = true;
	}
}
