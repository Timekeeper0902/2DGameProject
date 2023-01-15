using System;
using Timekeeper.Panel.PausePanel;
using UnityEngine;

namespace Timekeeper._Scripts.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        private void Update()
        {
            if (PlayerInputHandler.Instance.EscInput && PausePanel.Instance.canPause)
            {
                PausePanel.Instance.ShowMe();
                PausePanel.Instance.Enter();
            }
            else if (!PlayerInputHandler.Instance.EscInput && !PausePanel.Instance.canPause)
            {
                PausePanel.Instance.Exit();
                PausePanel.Instance.HideMe();
            }
        }
    }
}