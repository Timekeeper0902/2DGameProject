using System.Collections;
using System.Collections.Generic;
using Timekeeper.Player.Data;
using UnityEngine;

public class PlayerCrouchIdleState : PlayerGroundedState {
	public PlayerCrouchIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, PlayerAudioData audioData, string animBoolName) : base(player, stateMachine, playerData, audioData, animBoolName)
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
