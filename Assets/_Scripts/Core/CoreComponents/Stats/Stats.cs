using System;
using UnityEngine;

namespace Timekeeper.CoreSystem
{
    public class Stats : CoreComponent
    {
        public event Action OnHealthZero;
    
        public float maxHealth;
        public float CurrentHealth { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            CurrentHealth = maxHealth;
        }

        /// <summary>
        /// 减少固定生命值
        /// </summary>
        /// <param name="amount">减少值</param>
        public void DecreaseHealth(float amount)
        {
            CurrentHealth -= amount;

            //死亡判断
            if(CurrentHealth <= 0)
            {
                CurrentHealth = 0;
            
                OnHealthZero?.Invoke();
            
                Debug.Log("Health is zero!!");
            }
        }

        /// <summary>
        /// 恢复固定生命值
        /// </summary>
        /// <param name="amount">恢复值</param>
        public void IncreaseHealth(float amount)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, maxHealth);
        }

        /// <summary>
        /// 将当前生命值恢复到100%
        /// </summary>
        public void ReturnToMaxHealth()
        {
            CurrentHealth = maxHealth;
        }
    }
}
