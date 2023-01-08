using Timekeeper.Enemies.Data;
using UnityEngine;

namespace Timekeeper.Enemies.EnemySpecific.Enemy3
{
    public class E3_PlayerDetectedState : PlayerDetectedState
    {
        private Enemy3 enemy;

        public E3_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, EnemyAudioData audioData, string animBoolName, EnemyBaseData stateData, Enemy3 enemy) : base(entity, stateMachine, audioData, animBoolName, stateData)
        {
            this.enemy = enemy;
        }
        
        public override void Enter() {
            base.Enter();
        }

        public override void Exit() {
            base.Exit();
        }

        /// <summary>
        /// 转换状态相关
        /// </summary>
        public override void LogicUpdate() {
            base.LogicUpdate();

            if (performCloseRangeAction && enemy.E3_meleeAttackCounter == 0)
            {
                stateMachine.ChangeState(enemy.meleeAttackState);
                enemy.E3_meleeAttackCounter++;
            }
            else if (performCloseRangeAction && enemy.E3_meleeAttackCounter == 1)
            {
                stateMachine.ChangeState(enemy.meleeAttackState1);
                enemy.E3_meleeAttackCounter--;
                Debug.Log(enemy.E3_meleeAttackCounter);
            }
            else if (performLongRangeAction) {
                stateMachine.ChangeState(enemy.chargeState);
            }
            else if (!isPlayerInMaxAgroRange) {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            } 
            else if (!isDetectingLedge) {
                Movement?.Flip();
                stateMachine.ChangeState(enemy.moveState);
            }

        }

        public override void PhysicsUpdate() {
            base.PhysicsUpdate();
        }
    }
}