using System.Collections;
using System.Collections.Generic;
using Timekeeper._Panel;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState {
	public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, BaseAudioData baseAudioData, string animBoolName) : base(player, stateMachine, playerData, baseAudioData, animBoolName)
	{
	}

	public override void DoChecks() {
		base.DoChecks();
	}

	public override void Enter() {
		base.Enter();
		Movement?.SetVelocityX(0f);
	}

	public override void Exit() {
		base.Exit();
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		if (!isExitingState) {
			if (xInput != 0) {
				stateMachine.ChangeState(player.MoveState);
			} else if (yInput == -1) {
				stateMachine.ChangeState(player.CrouchIdleState);
			}
		}

	}

	public override void PhysicsUpdate() {
		base.PhysicsUpdate();
	}
}
