using System.Collections;
using System.Collections.Generic;
using Timekeeper._Panel;
using UnityEngine;

public class PlayerWallClimbState : PlayerTouchingWallState {
	public PlayerWallClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, BaseAudioData baseAudioData, string animBoolName) : base(player, stateMachine, playerData, baseAudioData, animBoolName)
	{
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		if (!isExitingState) {
			Movement?.SetVelocityY(playerData.wallClimbVelocity);

			if (yInput != 1) {
				stateMachine.ChangeState(player.WallGrabState);
			}
		}


	}
}
