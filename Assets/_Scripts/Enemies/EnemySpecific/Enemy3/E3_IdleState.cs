using Timekeeper._Panel;
using Timekeeper.Enemies.Data;
using UnityEngine;

namespace Timekeeper.Enemies.EnemySpecific.Enemy3
{
    public class E3_IdleState : IdleState
    {
        private Enemy3 enemy;

        public E3_IdleState(Entity entity, FiniteStateMachine stateMachine, BaseAudioData baseAudioData, string animBoolName, EnemyBaseData stateData, Enemy3 enemy) : base(entity, stateMachine, baseAudioData, animBoolName, stateData)
        {
            this.enemy = enemy;
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

            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(enemy.playerDetectedState);
            }
            else if (isIdleTimeOver)
            {
                stateMachine.ChangeState(enemy.moveState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}