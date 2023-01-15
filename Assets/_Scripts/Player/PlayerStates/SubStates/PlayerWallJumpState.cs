using System.Collections;
using System.Collections.Generic;
using Timekeeper.Player.Data;
using UnityEngine;

public class PlayerWallJumpState : PlayerAbilityState {
	private int wallJumpDirection;

	public PlayerWallJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, PlayerAudioData audioData, string animBoolName) : base(player, stateMachine, playerData, audioData, animBoolName)
	{
	}

	public override void Enter() {
		base.Enter();
		PlayerInputHandler.Instance.UseJumpInput();
		//player.JumpState.ResetAmountOfJumpsLeft();
		Movement?.SetVelocity(playerData.wallJumpVelocity, playerData.wallJumpAngle, wallJumpDirection);
		Movement?.CheckIfShouldFlip(wallJumpDirection);
		player.JumpState.DecreaseAmountOfJumpsLeft();
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		player.Anim.SetFloat("yVelocity", Movement.CurrentVelocity.y);
		player.Anim.SetFloat("xVelocity", Mathf.Abs(Movement.CurrentVelocity.x));

		if (Time.time >= startTime + playerData.wallJumpTime) {
			isAbilityDone = true;
		}
	}

	public void DetermineWallJumpDirection(bool isTouchingWall) {
		if (isTouchingWall) {
			wallJumpDirection = -Movement.FacingDirection;
		} else {
			wallJumpDirection = Movement.FacingDirection;
		}
	}
}
