using Timekeeper.Enemies.Data;
using UnityEngine;

namespace Timekeeper.Enemies.EnemySpecific.Enemy3
{
    public class Enemy3 : Entity
    {
        public E3_IdleState idleState { get; private set; }
        public E3_MoveState moveState { get; private set; }
        public E3_PlayerDetectedState playerDetectedState { get; private set; }
        public E3_ChargeState chargeState { get; private set; }
        public E3_LookForPlayerState lookForPlayerState { get; private set; }
        public E3_MeleeAttackState meleeAttackState { get; private set; }
        public E3_MeleeAttackState1 meleeAttackState1 { get; private set; }
        // public E3_StunState stunState { get; private set; }
        // public E3_DeadState deadState { get; private set; }
        
        public int E3_meleeAttackCounter;

        [SerializeField] private EnemyBaseData stateData;

        [SerializeField] private EnemyAudioData _audioData;


        [SerializeField] private Transform meleeAttackPosition;

        public override void Awake()
        {
            base.Awake();

            moveState = new E3_MoveState(this, stateMachine, _audioData,"move", stateData, this);
            idleState = new E3_IdleState(this, stateMachine, _audioData,"idle", stateData, this);
            playerDetectedState = new E3_PlayerDetectedState(this, stateMachine, _audioData,"playerDetected", stateData, this);
            chargeState = new E3_ChargeState(this, stateMachine, _audioData,"charge", stateData, this);
            lookForPlayerState = new E3_LookForPlayerState(this, stateMachine, _audioData,"lookForPlayer", stateData, this);
            meleeAttackState = new E3_MeleeAttackState(this, stateMachine, _audioData,"meleeAttack", meleeAttackPosition, stateData, this);
            meleeAttackState1 = new E3_MeleeAttackState1(this, stateMachine, _audioData,"meleeAttack1", meleeAttackPosition, stateData, this);
            // stunState = new E1_StunState(this, stateMachine, _audioData,"stun", stateData, this);
            // deadState = new E1_DeadState(this, stateMachine, _audioData,"dead", stateData, this);


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
}