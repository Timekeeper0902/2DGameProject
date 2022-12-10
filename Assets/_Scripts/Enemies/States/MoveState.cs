using System.Collections;
using System.Collections.Generic;
using Timekeeper.CoreSystem;
using Timekeeper.Enemies.EnemySpecific.Enemy1;
using UnityEngine;

public class MoveState : State {
	private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
	private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }

	private Movement movement;
	private CollisionSenses collisionSenses;

	protected EnemyBaseData stateData;

	protected bool isDetectingWall;
	protected bool isDetectingLedge;
	protected bool isPlayerInMinAgroRange;

	public MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, EnemyBaseData stateData) : base(entity, stateMachine, animBoolName) {
		this.stateData = stateData;
	}

	public override void DoChecks() {
		base.DoChecks();

		isDetectingLedge = CollisionSenses.LedgeVertical;
		isDetectingWall = CollisionSenses.WallFront;
		isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
	}

	public override void Enter() {
		base.Enter();
		Movement?.SetVelocityX(stateData.movementSpeed * Movement.FacingDirection);

	}

	public override void Exit() {
		base.Exit();
	}

	public override void LogicUpdate() {
		base.LogicUpdate();
		Movement?.SetVelocityX(stateData.movementSpeed * Movement.FacingDirection);
	}

	public override void PhysicsUpdate() {
		base.PhysicsUpdate();
	}
}
