using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Timekeeper.Panel.PausePanel
{
    public class PausePanel : Singleton<PausePanel>
    {
        public Button backToGame;
        public Button gameSetting;
        public Button information;
        public Button quitGame;

        public bool canPause = true;

        [SerializeField] private Animator anim;

        private PlayerInputHandler _inputHandler;
        private GameObject children;

        private void Start()
        {
            _inputHandler = GameObject.Find("Player").GetComponent<PlayerInputHandler>();
            children = this.transform.GetChild(0).gameObject;
            anim = GetComponent<Animator>();
            backToGame.onClick.AddListener(Exit);
        }

        private void Update()
        {
            if (_inputHandler.EscInput && canPause)
            {
                Enter();
            }
            else if (!_inputHandler.EscInput && !canPause)
            {
                Exit();
            }
        }

        private void Enter()
        {
            anim.SetBool("quit", false);
            anim.SetBool("enter", true);
            StartCoroutine(DelayToPauseTime());
        }

        private void Exit()
        {
            StopCoroutine(DelayToPauseTime());
            Time.timeScale = 1f;
            anim.SetBool("enter", false);
            anim.SetBool("quit", true);
            canPause = true;
        }

        public IEnumerator DelayToPauseTime()
        {
            yield return new WaitForSeconds(0.4f);
            Time.timeScale = 0f;
            canPause = false;
        }

    }
}