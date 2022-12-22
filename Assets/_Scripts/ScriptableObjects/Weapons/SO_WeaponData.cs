using UnityEngine;

namespace Timekeeper.ScriptableObjects.Weapons
{
    
    [CreateAssetMenu(fileName = "newWeaponData", menuName = "数据/武器数据/武器")]
    public class SO_WeaponData : ScriptableObject
    {
        public int AmountOfAttacks { get; protected set; }
        public float attackHoldTime = 2f;
        public float[] MovementSpeed { get; protected set; }
    }
}