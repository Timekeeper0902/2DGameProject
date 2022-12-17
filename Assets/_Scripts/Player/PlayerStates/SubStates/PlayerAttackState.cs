using System.Collections;
using System.Collections.Generic;
using Timekeeper.Player.Data;
using Timekeeper.Weapons;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private Weapon weapon;


    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, PlayerAudioData audioData, string animBoolName, Weapon weapon) : base(player, stateMachine, playerData, audioData, animBoolName)
    {
        this.weapon = weapon;
        weapon.OnExit += ExitHandler;
    }



    public override void Enter()
    {
        base.Enter();
        
        weapon.Enter();
    }

    private void ExitHandler()
    {
        AnimationFinishTrigger();
        isAbilityDone = true;
    }
}