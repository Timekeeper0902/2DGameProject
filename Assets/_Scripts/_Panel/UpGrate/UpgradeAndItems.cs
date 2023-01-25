using System;
using Timekeeper.CoreSystem;
using UnityEngine;

namespace Timekeeper._Panel.UpGrate
{
    public class UpgradeAndItems : Singleton<UpgradeAndItems>
    {
        public int currentExp;
        public int currentLevel = 1;
        
        public UpgradeData upgradeData;
        public PlayerData data;
        public Stats stats;

        private void Awake()
        {
            stats = GameObject.Find("Player").GetComponentInChildren<Stats>();
        }
        

        public void AddExperience(int num)
        {
            currentExp += num;
            for (int i = 0; i < upgradeData.ExperienceData.Length; i++)
            {
                if (currentExp >= upgradeData.ExperienceData[i].nextLevelExp)
                {
                    currentLevel = upgradeData.ExperienceData[i].targetLevel;
                }
            }
            
            if(currentLevel == 1)
                return;
            else if(currentLevel == 2)
            {
                stats.maxHealth += 20;
                data.dashCooldown = 8;
            }
        }
    }
}