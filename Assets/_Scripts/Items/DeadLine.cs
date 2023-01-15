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
        private Stats _enemyStats;

        private void Start()
        {
            _stats = GameObject.Find("Player").GetComponentInChildren<Stats>();
            //_enemyStats = GameObject.Find("Enemy").GetComponentInChildren<Stats>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
            {
                _stats.DecreaseHealth(_stats.maxHealth);
            }
            if (other.gameObject.CompareTag("Enemy") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
            {
                print("xxx");
                _enemyStats = other.GetComponentInChildren<Stats>();
                _enemyStats.DecreaseHealth(_stats.maxHealth);
            }
        }
    }
}
