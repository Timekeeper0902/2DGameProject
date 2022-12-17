using System.Collections;
using System.Collections.Generic;
using Timekeeper.Player.Data;
using UnityEngine;

public class PlayerWallSlideState : PlayerTouchingWallState {
	public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, PlayerAudioData audioData, string animBoolName) : base(player, stateMachine, playerData, audioData, animBoolName)
	{
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		if (!isExitingState) {
			Movement?.SetVelocityY(-playerData.wallSlideVelocity);

			if (grabInput && yInput == 0) {
				stateMachine.ChangeState(player.WallGrabState);
			}
		}

	}
}
