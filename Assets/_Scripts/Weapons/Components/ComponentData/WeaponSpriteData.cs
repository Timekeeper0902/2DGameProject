using Timekeeper.Weapons.Components.ComponentData.AttackData;
using UnityEngine;

namespace Timekeeper.Weapons.Components.ComponentData
{
    public class WeaponSpriteData : ComponentData
    {
        [field: SerializeField] public AttackSprites[] AttackData { get; private set; }
    }
}