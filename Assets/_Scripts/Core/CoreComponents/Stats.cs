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

        public void DecreaseHealth(float amount)
        {
            CurrentHealth -= amount;

            if(CurrentHealth <= 0)
            {
                CurrentHealth = 0;
            
                OnHealthZero?.Invoke();
            
                Debug.Log("Health is zero!!");
            }
        }

        public void IncreaseHealth(float amount)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, maxHealth);
        }
    }
}
