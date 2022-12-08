using System;
using System.Collections;
using System.Collections.Generic;
using Timekeeper.CoreSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Timekeeper
{
    public class Bloodbar : MonoBehaviour
    {
        public Image bloodBar;

        public Stats stats;

        public GameObject bloodEffect;

        private float _preHealth;
        private float _curHealth;

        private void Update()
        {
            _preHealth = bloodBar.fillAmount;
            _curHealth = stats.CurrentHealth / stats.maxHealth;
            bloodBar.fillAmount = _curHealth;
            if (_preHealth != bloodBar.fillAmount)
            {
                GameObject obj = Instantiate(bloodEffect, this.transform.parent);
                obj.transform.SetAsLastSibling();
            
                obj.GetComponent<BloodbarEffect>().IniBloodBarEffect(_curHealth,_preHealth);
            }

            
        }
    }
}
