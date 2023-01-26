using Timekeeper._Panel.UpGrate;
using Timekeeper.CoreSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Timekeeper
{
    public class Bloodbar : Singleton<Bloodbar>
    {
        public Image bloodBar;
        public Stats stats;
        public GameObject bloodEffect;
        public Text nowLevel;
        
        public Image dashFill;
        public PlayerData playerData;
        public Image dashReady;
        
        public Image enemyBloodBar;

        private float _preHealth;
        private float _curHealth;

        private void Awake()
        {
            stats = GameObject.Find("Player").GetComponentInChildren<Stats>();
            playerData.lastDashTime = -1f;
        }

        private void Update()
        {
            CheckBlood();
            CheckDash();
        }

        public void CheckBlood()
        {
            _preHealth = bloodBar.fillAmount;
            
            _curHealth = stats.CurrentHealth / stats.maxHealth;
            bloodBar.fillAmount = _curHealth;
            if (_preHealth != bloodBar.fillAmount)
            {
                GameObject obj = Instantiate(bloodEffect, this.transform.GetChild(0));
                obj.transform.SetAsLastSibling();
                obj.GetComponent<BloodbarEffect>().IniBloodBarEffect(_curHealth,_preHealth);
            }

            nowLevel.text = UpgradeAndItems.Instance.currentLevel.ToString();
        }

        public void CheckDash()
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
