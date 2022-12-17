﻿using System.Collections;
using System.Collections.Generic;
using Timekeeper.Player.Data;
using UnityEngine;

public class PlayerCrouchMoveState : PlayerGroundedState {
	public PlayerCrouchMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, PlayerAudioData audioData, string animBoolName) : base(player, stateMachine, playerData, audioData, animBoolName)
	{
	}

	public override void Enter() {
		base.Enter();
		player.SetColliderHeight(playerData.crouchColliderHeight);
	}

	public override void Exit() {
		base.Exit();
		player.SetColliderHeight(playerData.standColliderHeight);
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		if (!isExitingState) {
			Movement?.SetVelocityX(playerData.crouchMovementVelocity * Movement.FacingDirection);
			Movement?.CheckIfShouldFlip(xInput);

			if (xInput == 0) {
				stateMachine.ChangeState(player.CrouchIdleState);
			} else if (yInput != -1 && !isTouchingCeiling) {
				stateMachine.ChangeState(player.MoveState);
			}
		}

	}
}
