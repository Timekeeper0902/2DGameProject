using System.Collections;
using System.Collections.Generic;
using Timekeeper.Enemies.Data;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState idleState { get; private set; }
    public E1_MoveState moveState { get; private set; }
    public E1_PlayerDetectedState playerDetectedState { get; private set; }
    public E1_ChargeState chargeState { get; private set; }
    public E1_LookForPlayerState lookForPlayerState { get; private set; }
    public E1_MeleeAttackState meleeAttackState { get; private set; }
    public E1_StunState stunState { get; private set; }
    public E1_DeadState deadState { get; private set; }

    [SerializeField]
    private EnemyBaseData stateData;

    [SerializeField] private EnemyAudioData _audioData;


    [SerializeField]
    private Transform meleeAttackPosition;

    public override void Awake()
    {
        base.Awake();

        moveState = new E1_MoveState(this, stateMachine, _audioData,"move", stateData, this);
        idleState = new E1_IdleState(this, stateMachine, _audioData,"idle", stateData, this);
        playerDetectedState = new E1_PlayerDetectedState(this, stateMachine, _audioData,"playerDetected", stateData, this);
        chargeState = new E1_ChargeState(this, stateMachine, _audioData,"charge", stateData, this);
        lookForPlayerState = new E1_LookForPlayerState(this, stateMachine, _audioData,"lookForPlayer", stateData, this);
        meleeAttackState = new E1_MeleeAttackState(this, stateMachine, _audioData,"meleeAttack", meleeAttackPosition, stateData, this);
        stunState = new E1_StunState(this, stateMachine, _audioData,"stun", stateData, this);
        deadState = new E1_DeadState(this, stateMachine, _audioData,"dead", stateData, this);

       
    }

    private void Start()
    {
        stateMachine.Initialize(moveState);        
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireCube(meleeAttackPosition.position, stateData.attackBoxArea);
    }
}
