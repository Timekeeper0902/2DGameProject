using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Timekeeper.Panel.PausePanel
{
    public class GameStatsPanel : Singleton<GameStatsPanel>
    {
        public Text deathTime;
        public Text timeSpend;

        private void Start()
        {
            HideMe();
        }

        private void Update()
        {
            if (PausePanel.Instance.canPause == false)
            {
                deathTime.text = ReSpawnManager.Instance.deathTimes.ToString();
                timeSpend.text = ReSpawnManager.Instance.gameTime.ToString();
            }
        }
    }
}