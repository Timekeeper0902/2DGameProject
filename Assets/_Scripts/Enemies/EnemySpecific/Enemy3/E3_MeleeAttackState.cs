using Timekeeper.Enemies.Data;
using UnityEngine;

namespace Timekeeper.Enemies.EnemySpecific.Enemy3
{
    public class E3_MeleeAttackState : MeleeAttackState
    {
        private Enemy3 enemy;

        public E3_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, EnemyAudioData audioData, string animBoolName, Transform attackPosition, EnemyBaseData stateData, Enemy3 enemy) : base(entity, stateMachine, audioData, animBoolName, attackPosition, stateData)
        {
            this.enemy = enemy;
        }
        
        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void FinishAttack()
        {
            base.FinishAttack();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isAnimationFinished)
            {
                if (isPlayerInMinAgroRange)
                {
                    stateMachine.ChangeState(enemy.playerDetectedState);
                }
                else
                {
                    stateMachine.ChangeState(enemy.lookForPlayerState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void TriggerAttack()
        {
            base.TriggerAttack();
        }
    }
}