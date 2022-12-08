using System;
using System.Collections;
using System.Collections.Generic;
using Timekeeper.CoreSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Timekeeper
{
    public class DashBar : MonoBehaviour
    {
        public Image dashFill;

        public PlayerData playerData;

        public Image dashReady;

        private void Awake()
        {
            //playerData = GameObject.Find("Player").GetComponent<PlayerData>();
            playerData.lastDashTime = -1f;
        }

        private void Update()
        {
            if (Time.time - playerData.lastDashTime < playerData.dashCooldown)
            {
                dashReady.gameObject.SetActive(false);
                dashFill.fillAmount = (Time.time - playerData.lastDashTime)/ playerData.dashCooldown;
            }
            else
            {
                dashReady.gameObject.SetActive(true);
            }
            
        }
    }
}
