using System.Collections.Generic;
using System.Linq;
using Timekeeper.Weapons.Components.ComponentData;
using UnityEngine;

namespace Timekeeper.Weapons
{
    [CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Basic Weapon Data", order = 0)]
    public class WeaponDataSO : ScriptableObject
    {
        [field: SerializeField] public int NumberOfAttacks { get; private set; }

        [field: SerializeReference] public List<ComponentData> ComponentData { get; private set; }

        public T GetData<T>()
        {
            return ComponentData.OfType<T>().FirstOrDefault();
        }

        [ContextMenu("添加武器动画")]
        private void AddSpriteData() => ComponentData.Add(new WeaponSpriteData());
        
        [ContextMenu("添加移动数据")]
        private void AddMovementData() => ComponentData.Add(new MovementData());
    }
}