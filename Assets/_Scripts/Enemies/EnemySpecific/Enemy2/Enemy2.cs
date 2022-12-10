using System.Collections;
using System.Collections.Generic;
using Timekeeper.Enemies.EnemySpecific.Enemy1;
using UnityEngine;

public class Enemy2 : Entity
{   
    public E2_MoveState moveState { get; private set; }
    public E2_IdleState idleState { get; private set; }
    public E2_PlayerDetectedState playerDetectedState { get; private set; }
    public E2_MeleeAttackState meleeAttackState { get; private set; }
    public E2_LookForPlayerState lookForPlayerState { get; private set; }
    public E2_StunState stunState { get; private set; }
    public E2_DeadState deadState { get; private set; }
    public E2_DodgeState dodgeState { get; private set; }
    public E2_RangedAttackState rangedAttackState { get; private set; }
    
    [SerializeField] public Timekeeper.Enemies.EnemySpecific.Enemy1.EnemyBaseData stateData;

    [SerializeField]
    private Transform meleeAttackPosition;
    [SerializeField]
    private Transform rangedAttackPosition;

    public override void Awake()
    {
        base.Awake();

        moveState = new E2_MoveState(this, stateMachine, "move", stateData, this);
        idleState = new E2_IdleState(this, stateMachine, "idle", stateData, this);
        playerDetectedState = new E2_PlayerDetectedState(this, stateMachine, "playerDetected", stateData, this);
        meleeAttackState = new E2_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, stateData, this);
        lookForPlayerState = new E2_LookForPlayerState(this, stateMachine, "lookForPlayer", stateData, this);
        stunState = new E2_StunState(this, stateMachine, "stun", stateData, this);
        deadState = new E2_DeadState(this, stateMachine, "dead", stateData, this);
        dodgeState = new E2_DodgeState(this, stateMachine, "dodge", stateData, this);
        rangedAttackState = new E2_RangedAttackState(this, stateMachine, "rangedAttack", rangedAttackPosition, stateData, this);

    }

    private void Start()
    {
        stateMachine.Initialize(moveState);        
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, stateData.attackRadius);
    }
}
