using System.Collections;
using System.Collections.Generic;
using Timekeeper.Player.Data;
using Timekeeper.Weapons;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private Weapon weapon;

    private int xInput;

    private float velocityToSet;

    private bool setVelocity;
    private bool shouldCheckFlip;


    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, PlayerAudioData audioData, string animBoolName) : base(player, stateMachine, playerData, audioData, animBoolName)
    {
    }

    public override void Enter() {
        base.Enter();

        setVelocity = false;

        weapon.EnterWeapon();
    }

    public override void Exit() {
        base.Exit();

        weapon.ExitWeapon();
    }

    public override void LogicUpdate() {
        base.LogicUpdate();

        xInput = PlayerInputHandler.Instance.NormInputX;

        if (shouldCheckFlip) {
            Movement?.CheckIfShouldFlip(xInput);
        }


        if (setVelocity) {
            Movement?.SetVelocityX(velocityToSet * Movement.FacingDirection);
        }
    }

    public void SetWeapon(Weapon weapon) {
        this.weapon = weapon;
        this.weapon.InitializeWeapon(this, core);
    }

    public void SetPlayerVelocity(float velocity) {
        Movement.SetVelocityX(velocity * Movement.FacingDirection);

        velocityToSet = velocity;
        setVelocity = true;
    }

    public void SetFlipCheck(bool value) {
        shouldCheckFlip = value;
    }

    #region Animation Triggers

    public override void AnimationFinishTrigger() {
        base.AnimationFinishTrigger();

        isAbilityDone = true;
    }

    #endregion
}