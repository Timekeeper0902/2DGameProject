using System;
using System.Collections;
using System.Collections.Generic;
using Timekeeper.CoreSystem;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Serialization;

namespace Timekeeper._Scripts.Enemies
{
    public class FlyEntity : MonoBehaviour, IDamageable
    {
        public float moveSpeed;
        public float attakNum;
        public float idleTime;
        public float health = 75;
        public Transform[] idlePoints;
        protected Transform chasePoint;
        
        public GameObject hitParticles;
        public GameObject floatPoint;
        
        public GameObject player;
        public float castRadius;
        public LayerMask whatIsPlayer;

        protected Rigidbody2D rb;
        
        /// <summary>
        /// 查找玩家
        /// </summary>
        /// <returns></returns>
        public virtual bool CheckPlayer() 
        {
            return Physics2D.OverlapCircle(this.transform.position,castRadius,whatIsPlayer);
        }

        /// <summary>
        /// 画出查找范围
        /// </summary>
        public virtual void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(this.transform.position, castRadius);
        }

        /// <summary>
        /// 受到伤害
        /// </summary>
        /// <param name="amount"></param>
        public virtual void Damage(float amount)
        {
            health -= amount;
            Death(health);
        }

        /// <summary>
        /// 死亡
        /// </summary>
        /// <param name="hp"></param>
        public virtual void Death(float hp)
        {
            if (hp <= 0)
            {
                hp = 0;
                gameObject.SetActive(false);
            }
        }

        protected virtual void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                float time = 1;
                player.GetComponentInChildren<Stats>().DecreaseHealth(attakNum);
                while (time > 0)
                {
                    time -= Time.deltaTime;
                }
            }
        }
        
        public virtual void TriggerAttack() {
            
            Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(this.transform.position, 0.5f, whatIsPlayer);

            foreach (Collider2D collider in detectedObjects)
            {
                IDamageable damageable = collider.GetComponent<IDamageable>();

                if (damageable != null)
                {
                    damageable.Damage(attakNum);

                }
            }
        }

        public virtual void FinishAttack() {
            
        }

    }
}