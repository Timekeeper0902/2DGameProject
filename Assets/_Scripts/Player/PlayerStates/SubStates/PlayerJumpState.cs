using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Timekeeper;
using Timekeeper.Player.Data;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState 
{
	private int _amountOfJumpsLeft;

	public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, PlayerAudioData audioData, string animBoolName) : base(player, stateMachine, playerData, audioData, animBoolName)
	{
		_amountOfJumpsLeft = playerData.amountOfJumps;
	}

	public override void Enter() 
	{
		base.Enter();
		player.InputHandler.UseJumpInput();
		Movement?.SetVelocityY(playerData.jumpVelocity);
		isAbilityDone = true;
		_amountOfJumpsLeft--;
		player.InAirState.SetIsJumping();
		AudioManager.Instance.PlayerJumpPlay(audioData.jumpClip);
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
