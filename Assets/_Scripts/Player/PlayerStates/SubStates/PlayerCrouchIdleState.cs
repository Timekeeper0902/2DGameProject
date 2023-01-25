using System.Collections;
using System.Collections.Generic;
using Timekeeper._Panel;
using UnityEngine;

public class PlayerCrouchIdleState : PlayerGroundedState {
	public PlayerCrouchIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, BaseAudioData baseAudioData, string animBoolName) : base(player, stateMachine, playerData, baseAudioData, animBoolName)
	{
	}

	public override void Enter() {
		base.Enter();

		Movement?.SetVelocityZero();
		player.SetColliderHeight(playerData.crouchColliderHeight);
	}

	public override void Exit() {
		base.Exit();
		player.SetColliderHeight(playerData.standColliderHeight);
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		if (!isExitingState) {
			if (xInput != 0) {
				stateMachine.ChangeState(player.CrouchMoveState);
			} else if (yInput != -1 && !isTouchingCeiling) {
				stateMachine.ChangeState(player.IdleState);
			}
		}
	}
}
