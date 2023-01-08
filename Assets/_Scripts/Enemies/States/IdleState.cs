﻿using System.Collections;
using System.Collections.Generic;
using Timekeeper.CoreSystem;
using Timekeeper.Enemies.Data;
using UnityEngine;

public class IdleState : State {
	public IdleState(Entity entity, FiniteStateMachine stateMachine, EnemyAudioData audioData, string animBoolName, EnemyBaseData stateData) : base(entity, stateMachine, audioData, animBoolName)
	{
		this.stateData = stateData;
	}

	private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
	private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }

	private Movement movement;
	private CollisionSenses collisionSenses;

	protected Timekeeper.Enemies.Data.EnemyBaseData stateData;

	protected bool flipAfterIdle;
	protected bool isIdleTimeOver;
	protected bool isPlayerInMinAgroRange;

	protected float idleTime;

	

	public override void DoChecks() {
		base.DoChecks();
		isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
	}

	public override void Enter() {
		base.Enter();

		Movement?.SetVelocityX(0f);
		isIdleTimeOver = false;
		SetRandomIdleTime();
	}

	public override void Exit() {
		base.Exit();

		if (flipAfterIdle) {
			Movement?.Flip();
		}
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		Movement?.SetVelocityX(0f);

		if (Time.time >= startTime + idleTime) {
			isIdleTimeOver = true;
		}
	}

	public override void PhysicsUpdate() {
		base.PhysicsUpdate();
	}

	public void SetFlipAfterIdle(bool flip) {
		flipAfterIdle = flip;
	}

	private void SetRandomIdleTime() {
		idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
	}
}
