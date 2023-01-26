using System;
using Timekeeper._Panel.UpGrate;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Timekeeper.Panel.PausePanel
{
    public class GameStatsPanel : Singleton<GameStatsPanel>
    {
        public Text deathTime;
        public Text timeSpend;

        public Text nowLevel;
        public Image showHp;
        public Text HpText;
        public Text dashCD;
        public Text experienceText;
        public Image nowExprience;

        private void Start()
        {
            HideMe();
        }

        private void Update()
        {
            if (PausePanel.Instance.canPause == false)
            {
                deathTime.text = ReSpawnManager.Instance.deathTimes.ToString();
                timeSpend.text = Mathf.FloorToInt(ReSpawnManager.Instance.gameTime).ToString();
                nowLevel.text = UpgradeAndItems.Instance.currentLevel.ToString();
                showHp.fillAmount = UpgradeAndItems.Instance.stats.CurrentHealth /
                                    UpgradeAndItems.Instance.stats.maxHealth;
                HpText.text = UpgradeAndItems.Instance.stats.CurrentHealth.ToString() + "/" +
                              UpgradeAndItems.Instance.stats.maxHealth;
                dashCD.text = UpgradeAndItems.Instance.data.dashCooldown.ToString() + "秒";
                if (UpgradeAndItems.Instance.currentLevel == 1)
                {
                    experienceText.text = UpgradeAndItems.Instance.currentExp.ToString() + "/" +
                                          UpgradeAndItems.Instance.upgradeData.ExperienceData[0].nextLevelExp.ToString();
                    nowExprience.fillAmount = (float)UpgradeAndItems.Instance.currentExp /
                                              UpgradeAndItems.Instance.upgradeData.ExperienceData[0].nextLevelExp;
                }
                else if(UpgradeAndItems.Instance.currentLevel == 2)
                {
                    experienceText.text = UpgradeAndItems.Instance.currentExp.ToString() + "/" +
                                          UpgradeAndItems.Instance.upgradeData.ExperienceData[1].nextLevelExp;
                    nowExprience.fillAmount = (float)UpgradeAndItems.Instance.currentExp /
                                              UpgradeAndItems.Instance.upgradeData.ExperienceData[1].nextLevelExp;
                }
                else if(UpgradeAndItems.Instance.currentLevel == 3)
                {
                    experienceText.text = UpgradeAndItems.Instance.currentExp.ToString() + "/" +
                                          UpgradeAndItems.Instance.upgradeData.ExperienceData[2].nextLevelExp;
                    nowExprience.fillAmount = (float)UpgradeAndItems.Instance.currentExp /
                                              UpgradeAndItems.Instance.upgradeData.ExperienceData[2].nextLevelExp;
                }
                
            }
        }
    }
}