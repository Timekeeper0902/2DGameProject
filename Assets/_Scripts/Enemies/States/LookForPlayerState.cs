using System.Collections;
using System.Collections.Generic;
using Timekeeper._Panel;
using Timekeeper.CoreSystem;
using Timekeeper.Enemies.Data;
using UnityEngine;

public class LookForPlayerState : State {
	public LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, BaseAudioData baseAudioData, string animBoolName, EnemyBaseData stateData) : base(entity, stateMachine, baseAudioData, animBoolName)
	{
		this.stateData = stateData;
	}

	private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
	private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }

	private Movement movement;
	private CollisionSenses collisionSenses;

	protected EnemyBaseData stateData;

	protected bool turnImmediately;
	protected bool isPlayerInMinAgroRange;
	protected bool isAllTurnsDone;
	protected bool isAllTurnsTimeDone;

	protected float lastTurnTime;

	protected int amountOfTurnsDone;
	

	public override void DoChecks() {
		base.DoChecks();

		isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
	}

	public override void Enter() {
		base.Enter();

		isAllTurnsDone = false;
		isAllTurnsTimeDone = false;

		lastTurnTime = startTime;
		amountOfTurnsDone = 0;

		Movement?.SetVelocityX(0f);
	}

	public override void Exit() {
		base.Exit();
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		Movement?.SetVelocityX(0f);

		if (turnImmediately) {
			Movement?.Flip();
			lastTurnTime = Time.time;
			amountOfTurnsDone++;
			turnImmediately = false;
		} else if (Time.time >= lastTurnTime + stateData.timeBetweenTurns && !isAllTurnsDone) {
			Movement?.Flip();
			lastTurnTime = Time.time;
			amountOfTurnsDone++;
		}

		if (amountOfTurnsDone >= stateData.amountOfTurns) {
			isAllTurnsDone = true;
		}

		if (Time.time >= lastTurnTime + stateData.timeBetweenTurns && isAllTurnsDone) {
			isAllTurnsTimeDone = true;
		}
	}

	public override void PhysicsUpdate() {
		base.PhysicsUpdate();
	}

	public void SetTurnImmediately(bool flip) {
		turnImmediately = flip;
	}
}
