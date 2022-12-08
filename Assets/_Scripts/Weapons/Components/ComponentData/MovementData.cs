using Timekeeper.Weapons.Components.ComponentData.AttackData;
using UnityEngine;

namespace Timekeeper.Weapons.Components.ComponentData
{
    public class MovementData : ComponentData
    {
        [field: SerializeField] public AttackMovement[] AttackData { get; private set; }
    }
}