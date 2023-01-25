using Timekeeper._Panel;
using Timekeeper.Enemies.Data;
using UnityEngine;

namespace Timekeeper.Enemies.EnemySpecific.Enemy3
{
    public class E3_ChargeState : ChargeState
    {
        private Enemy3 enemy;

        public E3_ChargeState(Entity entity, FiniteStateMachine stateMachine, BaseAudioData baseAudioData, string animBoolName, EnemyBaseData stateData, Enemy3 enemy) : base(entity, stateMachine, baseAudioData, animBoolName, stateData)
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

        public override void LogicUpdate()
        {
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
            }
            else if (!isDetectingLedge || isDetectingWall)
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
            else if (isChargeTimeOver)
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
    }
}