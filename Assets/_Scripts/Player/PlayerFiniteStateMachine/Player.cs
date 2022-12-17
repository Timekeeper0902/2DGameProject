using System.Collections;
using System.Collections.Generic;
using Timekeeper.Player.Data;
using Timekeeper.CoreSystem;
using Timekeeper.Intermediaries;
using Timekeeper.Weapons;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }
    public AudioToAudio ATA { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerWallGrabState WallGrabState { get; private set; }
    public PlayerWallClimbState WallClimbState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }
    public PlayerLedgeClimbState LedgeClimbState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerCrouchIdleState CrouchIdleState { get; private set; }
    public PlayerCrouchMoveState CrouchMoveState { get; private set; }
    public PlayerAttackState PrimaryAttackState { get; private set; }
    public PlayerAttackState SecondaryAttackState { get; private set; }

    [SerializeField]
    private PlayerData playerData;

    [SerializeField] private PlayerAudioData audioData;
    #endregion

    #region Components
    public Core Core { get; private set; }
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public Transform DashDirectionIndicator { get; private set; }
    public BoxCollider2D MovementCollider { get; private set; }
    #endregion

    #region Other Variables         

    private Vector2 workspace;

    private Weapon primaryWeapon;
    private Weapon secondaryWeapon;
    
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        Core = GetComponentInChildren<Core>();

        ATA = gameObject.GetComponent<AudioToAudio>();

        primaryWeapon = transform.Find("PrimaryWeapon").GetComponent<Weapon>();
        secondaryWeapon = transform.Find("SecondaryWeapon").GetComponent<Weapon>();
        
        primaryWeapon.SetCore(Core);
        secondaryWeapon.SetCore(Core);
        
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, audioData,"idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, audioData,"move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, audioData,"inAir");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, audioData,"inAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, audioData,"land");
        WallSlideState = new PlayerWallSlideState(this, StateMachine, playerData, audioData,"wallSlide");
        WallGrabState = new PlayerWallGrabState(this, StateMachine, playerData, audioData,"wallGrab");
        WallClimbState = new PlayerWallClimbState(this, StateMachine, playerData,audioData, "wallClimb");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, playerData, audioData,"inAir");
        LedgeClimbState = new PlayerLedgeClimbState(this, StateMachine, playerData, audioData,"ledgeClimbState");
        DashState = new PlayerDashState(this, StateMachine, playerData,audioData, "inAir");
        CrouchIdleState = new PlayerCrouchIdleState(this, StateMachine, playerData, audioData,"crouchIdle");
        CrouchMoveState = new PlayerCrouchMoveState(this, StateMachine, playerData,audioData, "crouchMove");
        PrimaryAttackState = new PlayerAttackState(this, StateMachine, playerData, audioData,"attack", primaryWeapon);
        SecondaryAttackState = new PlayerAttackState(this, StateMachine, playerData, audioData,"attack", secondaryWeapon);
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        DashDirectionIndicator = transform.Find("DashDirectionIndicator");
        MovementCollider = GetComponent<BoxCollider2D>();

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        Core.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Other Functions

    public void SetColliderHeight(float height)
    {
        Vector2 center = MovementCollider.offset;
        workspace.Set(MovementCollider.size.x, height);

        center.y += (height - MovementCollider.size.y) / 2;

        MovementCollider.size = workspace;
        MovementCollider.offset = center;
    }   

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimtionFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

   
    #endregion
}
