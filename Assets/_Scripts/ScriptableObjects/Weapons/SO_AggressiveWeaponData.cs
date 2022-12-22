using Sirenix.OdinInspector;
using UnityEngine;

namespace Timekeeper.ScriptableObjects.Weapons
{
    [CreateAssetMenu(fileName = "newAggressiveWeaponData", menuName = "数据/武器数据/攻击型武器数据")]
    [InlineEditor]
    public class SO_AggressiveWeaponData : SO_WeaponData
    {
        [SerializeField] private WeaponAttackDetails[] attackDetails;

        public WeaponAttackDetails[] AttackDetails
        {
            get => attackDetails;
            private set => attackDetails = value;
        }

        private void OnEnable()
        {
            AmountOfAttacks = attackDetails.Length;

            MovementSpeed = new float[AmountOfAttacks];

            for (int i = 0; i < AmountOfAttacks; i++)
            {
                MovementSpeed[i] = attackDetails[i].movementSpeed;
            }
        }
    }
}