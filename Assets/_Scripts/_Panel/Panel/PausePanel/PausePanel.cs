using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Timekeeper.Panel.PausePanel
{
    public class PausePanel : Singleton<PausePanel>
    {
        public Button information;
        public Button gameSetting;
        public Button gameStats;
        public Button quitGame;

        public bool canPause = true;

        [SerializeField] private Animator anim;

        private GameObject children;
        


        private void Start()
        {
            children = this.transform.GetChild(0).gameObject;
            anim = GetComponent<Animator>();
            information.onClick.AddListener(OpenInfomationPanel);
            gameSetting.onClick.AddListener(OpenGameSettingPanel);
            gameStats.onClick.AddListener(OpenGameStatsPanel);
            quitGame.onClick.AddListener(OpenQuitGamePanel);
            HideMe();
        }

        private void Update()
        {
            
        }

        /// <summary>
        /// 进入暂停菜单
        /// </summary>
        public void Enter()
        {
            anim.SetBool("quit", false);
            anim.SetBool("enter", true);
            StartCoroutine(DelayToPauseTime());
        }

        /// <summary>
        /// 离开暂停菜单
        /// </summary>
        public void Exit()
        {
            QuitPanel.Instance.HideMe();
            GameStatsPanel.Instance.HideMe();
            InformationPanel.Instance.HideMe();
            GameSettingPanel.Instance.HideMe();
            anim.SetBool("enter", false);
            anim.SetBool("quit", true);
            StartCoroutine(DelayToPauseTime());
            Time.timeScale = 1f;
            canPause = true;
        }

        private void OpenInfomationPanel()
        {
            QuitPanel.Instance.HideMe();
            GameStatsPanel.Instance.HideMe();
            GameSettingPanel.Instance.HideMe();
            InformationPanel.Instance.ShowMe();
        }
        
        private void OpenGameSettingPanel()
        {
            QuitPanel.Instance.HideMe();
            GameStatsPanel.Instance.HideMe();
            InformationPanel.Instance.HideMe();
            GameSettingPanel.Instance.ShowMe();
        }
        
        private void OpenGameStatsPanel()
        {
            InformationPanel.Instance.HideMe();
            QuitPanel.Instance.HideMe();
            GameSettingPanel.Instance.HideMe();
            GameStatsPanel.Instance.ShowMe();
        }
        
        private void OpenQuitGamePanel()
        {
            InformationPanel.Instance.HideMe();
            QuitPanel.Instance.ShowMe();
            GameSettingPanel.Instance.HideMe();
            GameStatsPanel.Instance.HideMe();
        }

        public IEnumerator DelayToPauseTime()
        {
            yield return new WaitForSeconds(0.4f);
            Time.timeScale = 0f;
            canPause = false;
        }

    }
}