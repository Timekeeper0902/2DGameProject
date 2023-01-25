using System.Collections;
using System.Collections.Generic;
using Timekeeper._Panel;
using Timekeeper.Player;
using Timekeeper.CoreSystem;
using Timekeeper.Intermediaries;
using Timekeeper.Panel.PausePanel;
using Timekeeper.Weapons;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    #region 状态变量
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

    [FormerlySerializedAs("baseAudioData")] [FormerlySerializedAs("mainAudioData")] [SerializeField] private BaseAudioData _audioData;
    #endregion

    #region 组件
    public Core Core { get; private set; }
    public Animator Anim { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public Transform DashDirectionIndicator { get; private set; }
    public BoxCollider2D MovementCollider { get; private set; }
    public PlayerInventory Inventory { get; private set; }
    #endregion

    #region 其他变量  

    private Vector2 workspace;

    private Weapon primaryWeapon;
    private Weapon secondaryWeapon;
    
    #endregion

    #region 实例化状态
    private void Awake()
    {
        Core = GetComponentInChildren<Core>();

        ATA = gameObject.GetComponent<AudioToAudio>();
        
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, _audioData,"idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, _audioData,"move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, _audioData,"inAir");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, _audioData,"inAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, _audioData,"land");
        WallSlideState = new PlayerWallSlideState(this, StateMachine, playerData, _audioData,"wallSlide");
        WallGrabState = new PlayerWallGrabState(this, StateMachine, playerData, _audioData,"wallGrab");
        WallClimbState = new PlayerWallClimbState(this, StateMachine, playerData,_audioData, "wallClimb");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, playerData, _audioData,"inAir");
        LedgeClimbState = new PlayerLedgeClimbState(this, StateMachine, playerData, _audioData,"ledgeClimbState");
        DashState = new PlayerDashState(this, StateMachine, playerData,_audioData, "inAir");
        CrouchIdleState = new PlayerCrouchIdleState(this, StateMachine, playerData, _audioData,"crouchIdle");
        CrouchMoveState = new PlayerCrouchMoveState(this, StateMachine, playerData,_audioData, "crouchMove");
        PrimaryAttackState = new PlayerAttackState(this, StateMachine, playerData, _audioData,"attack" );
        SecondaryAttackState = new PlayerAttackState(this, StateMachine, playerData, _audioData,"attack");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        DashDirectionIndicator = transform.Find("DashDirectionIndicator");
        MovementCollider = GetComponent<BoxCollider2D>();
        Inventory = GetComponent<PlayerInventory>();
        
        PrimaryAttackState.SetWeapon(Inventory.weapons[(int)CombatInputs.primary]);
        SecondaryAttackState.SetWeapon(Inventory.weapons[(int)CombatInputs.secondary]);

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        if (PausePanel.Instance.canPause)
        {
            Core.LogicUpdate();
            StateMachine.CurrentState.LogicUpdate(); 
        }
        
        DontDestroyOnLoad(gameObject);
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
