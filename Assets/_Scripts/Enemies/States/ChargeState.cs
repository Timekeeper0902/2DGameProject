using System.Collections;
using System.Collections.Generic;
using Timekeeper.CoreSystem;
using Timekeeper.Enemies.EnemySpecific.Enemy1;
using UnityEngine;

public class ChargeState : State {
	private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
	private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }

	private Movement movement;
	private CollisionSenses collisionSenses;


	protected Timekeeper.Enemies.EnemySpecific.Enemy1.EnemyBaseData stateData;

	protected bool isPlayerInMinAgroRange;
	protected bool isDetectingLedge;
	protected bool isDetectingWall;
	protected bool isChargeTimeOver;
	protected bool performCloseRangeAction;

	public ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Timekeeper.Enemies.EnemySpecific.Enemy1.EnemyBaseData stateData) : base(entity, stateMachine, animBoolName) {
		this.stateData = stateData;
	}

	public override void DoChecks() {
		base.DoChecks();

		isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
		isDetectingLedge = CollisionSenses.LedgeVertical;
		isDetectingWall = CollisionSenses.WallFront;

		performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
	}

	public override void Enter() {
		base.Enter();

		isChargeTimeOver = false;
		Movement?.SetVelocityX(stateData.chargeSpeed * Movement.FacingDirection);
	}

	public override void Exit() {
		base.Exit();
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		Movement?.SetVelocityX(stateData.chargeSpeed * Movement.FacingDirection);

		if (Time.time >= startTime + stateData.chargeTime) {
			isChargeTimeOver = true;
		}
	}

	public override void PhysicsUpdate() {
		base.PhysicsUpdate();
	}
}
