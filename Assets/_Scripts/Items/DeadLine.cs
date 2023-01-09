using System;
using System.Collections;
using System.Collections.Generic;
using Timekeeper.CoreSystem;
using UnityEngine;

namespace Timekeeper
{
    public class DeadLine : MonoBehaviour
    {
        private Stats _stats;

        private void Awake()
        {
            _stats = GameObject.Find("Player").GetComponentInChildren<Stats>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
            {
                _stats.DecreaseHealth(_stats.maxHealth);
            }
        }
    }
}
