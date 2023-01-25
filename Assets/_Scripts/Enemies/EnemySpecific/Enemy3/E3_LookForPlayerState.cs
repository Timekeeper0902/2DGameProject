using Timekeeper._Panel;
using Timekeeper.Enemies.Data;
using UnityEngine;

namespace Timekeeper.Enemies.EnemySpecific.Enemy3
{
    public class E3_LookForPlayerState : LookForPlayerState
    {
        private Enemy3 enemy;

        public E3_LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, BaseAudioData baseAudioData, string animBoolName, EnemyBaseData stateData, Enemy3 enemy) : base(entity, stateMachine, baseAudioData, animBoolName, stateData)
        {
            this.enemy = enemy;
        }
        
        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(enemy.playerDetectedState);
            }
            else if (isAllTurnsTimeDone)
            {
                stateMachine.ChangeState(enemy.moveState);
            }
        }
    }
}