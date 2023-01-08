using System.Collections;
using System.Collections.Generic;
using Timekeeper.Enemies.Data;
using UnityEngine;

public class E1_PlayerDetectedState : PlayerDetectedState {
	private Enemy1 enemy;

	public E1_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, EnemyAudioData audioData, string animBoolName, EnemyBaseData stateData, Enemy1 enemy) : base(entity, stateMachine, audioData, animBoolName, stateData)
	{
		this.enemy = enemy;
	}

	public override void Enter() {
		base.Enter();
	}

	public override void Exit() {
		base.Exit();
	}

	/// <summary>
	/// 转换状态相关
	/// </summary>
	public override void LogicUpdate() {
		base.LogicUpdate();

		if (performCloseRangeAction) {
			stateMachine.ChangeState(enemy.meleeAttackState);
		} else if (performLongRangeAction) {
			stateMachine.ChangeState(enemy.chargeState);
		} else if (!isPlayerInMaxAgroRange) {
			stateMachine.ChangeState(enemy.lookForPlayerState);
		} else if (!isDetectingLedge) {
			Movement?.Flip();
			stateMachine.ChangeState(enemy.moveState);
		}

	}

	public override void PhysicsUpdate() {
		base.PhysicsUpdate();
	}
}
