using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Timekeeper;
using Timekeeper._Panel;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState 
{
	private int _amountOfJumpsLeft;

	public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, BaseAudioData baseAudioData, string animBoolName) : base(player, stateMachine, playerData, baseAudioData, animBoolName)
	{
		_amountOfJumpsLeft = playerData.amountOfJumps;
	}

	public override void Enter() 
	{
		base.Enter();
		PlayerInputHandler.Instance.UseJumpInput();
		Movement?.SetVelocityY(playerData.jumpVelocity);
		isAbilityDone = true;
		_amountOfJumpsLeft--;
		player.InAirState.SetIsJumping();
		AudioManager.Instance.PlayerJumpPlay(audioData.p_jumpClip);
	}

	public bool CanJump() 
	{
		if (_amountOfJumpsLeft > 0) 
		{
			return true;
		} 
		else 
		{
			return false;
		}
	}

	public void ResetAmountOfJumpsLeft() => _amountOfJumpsLeft = playerData.amountOfJumps;

	public void DecreaseAmountOfJumpsLeft() => _amountOfJumpsLeft--;
}
