using System;
using Timekeeper.CoreSystem;
using UnityEngine;

namespace Timekeeper.Player.UpGrate
{
    public class Upgrate : MonoBehaviour
    {
        public int playerLevel;
        public int maxLevel;
        public int currentExp;
        public int[] nextLevelExp;
        public PlayerData data;
        public Stats stats;


        private void Awake()
        {
            stats = GetComponentInChildren<Stats>();
        }
    }
}