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

        protected override void Awake()
        {
            stats = GameObject.Find("Player").GetComponentInChildren<Stats>();
        }

        private void Start()
        {
            currentExp = 0;
            currentLevel = 1;
            data.dashCooldown = 3f;
            data.amountOfJumps = 1;
        }


        public void AddExperience(int num)
        {
            currentExp += num;
            for (int i = 0; i < upgradeData.ExperienceData.Length; i++)
            {
                if (currentExp >= upgradeData.ExperienceData[i].nextLevelExp)
                {
                    int p = currentLevel;
                    currentLevel = upgradeData.ExperienceData[i].targetLevel;
                    if(currentLevel!=p)
                        CheckUpgradeInfo();
                }
            }
        }

        public void CheckUpgradeInfo()
        {
            if(currentLevel == 2)
            {
                stats.maxHealth += 20;
                data.dashCooldown = 8;
            }
        }
    }
}