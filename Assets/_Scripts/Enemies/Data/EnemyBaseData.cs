using Sirenix.OdinInspector;
using UnityEngine;

namespace Timekeeper.Enemies.Data
{
    [CreateAssetMenu(fileName = "敌人数据", menuName = "数据/敌人数据/敌人基本数据", order = 0)]
    [InlineEditor]
    public class EnemyBaseData : ScriptableObject
    {
        protected const string Enemy1IdleProperty= "Idle状态属性";
        protected const string Enemy1MoveProperty= "移动状态属性";
        protected const string Enemy1LookForPlayerProperty= "寻找玩家状态属性";
        protected const string Enemy1DeadProperty= "死亡状态属性";
        protected const string Enemy1MeleeAttackProperty= "近距离攻击状态属性";
        protected const string Enemy1RangedAttackProperty= "远距离攻击状态属性";
        protected const string Enemy1PlayerDetectedProperty= "发现玩家状态属性";
        protected const string Enemy1ChargeProperty= "冲刺状态属性";
        protected const string Enemy1DodgeProperty= "躲闪状态属性";
        protected const string Enemy1StunProperty= "眩晕状态属性";
        
        
        
        [FoldoutGroup("@Enemy1IdleProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public float minIdleTime = 1f;
        [FoldoutGroup("@Enemy1IdleProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public float maxIdleTime = 2f;
        
        [FoldoutGroup("@Enemy1MoveProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public float movementSpeed = 3f;
        
        
        [FoldoutGroup("@Enemy1LookForPlayerProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public int amountOfTurns = 2;
        [FoldoutGroup("@Enemy1LookForPlayerProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public float timeBetweenTurns = 0.75f;
        
        [FoldoutGroup("@Enemy1DeadProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public GameObject deathChunkParticle;
        [FoldoutGroup("@Enemy1DeadProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public GameObject deathBloodParticle;
        
        [FoldoutGroup("@Enemy1MeleeAttackProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public Vector2 attackBoxArea = Vector2.zero;
        [FoldoutGroup("@Enemy1MeleeAttackProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public float attackDamage = 10f;
        [FoldoutGroup("@Enemy1MeleeAttackProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public Vector2 knockbackAngle = Vector2.one;
        [FoldoutGroup("@Enemy1MeleeAttackProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public float knockbackStrength = 10f;
        [FoldoutGroup("@Enemy1MeleeAttackProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public LayerMask whatIsPlayer;
        
        [FoldoutGroup("@Enemy1RangedAttackProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public GameObject projectile;
        [FoldoutGroup("@Enemy1RangedAttackProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public float projectileDamage = 10f;
        [FoldoutGroup("@Enemy1RangedAttackProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public float projectileSpeed = 12f;
        [FoldoutGroup("@Enemy1RangedAttackProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public float projectileTravelDistance;
        
        [FoldoutGroup("@Enemy1PlayerDetectedProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public float longRangeActionTime = 1.5f;
        
        [FoldoutGroup("@Enemy1ChargeProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public float chargeSpeed = 6f;
        [FoldoutGroup("@Enemy1ChargeProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public float chargeTime = 2f;
        
        [FoldoutGroup("@Enemy1DodgeProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public float dodgeSpeed = 10f;
        [FoldoutGroup("@Enemy1DodgeProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public float dodgeTime = 0.2f;
        [FoldoutGroup("@Enemy1DodgeProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public float dodgeCooldown = 2f;
        [FoldoutGroup("@Enemy1DodgeProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public Vector2 dodgeAngle;
        
        [FoldoutGroup("@Enemy1StunProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public float stunTime = 3f;
        [FoldoutGroup("@Enemy1StunProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public float stunKnockbackTime = 0.2f;
        [FoldoutGroup("@Enemy1StunProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public float stunKnockbackSpeed = 20f;
        [FoldoutGroup("@Enemy1StunProperty"), LabelWidth(200), GUIColor(0.1f, 1f, 0.1f)]
        public Vector2 stunKnockbackAngle;
        
    }
}