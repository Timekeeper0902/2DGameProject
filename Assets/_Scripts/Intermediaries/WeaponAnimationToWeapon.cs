using Timekeeper.Weapons;
using UnityEngine;

namespace Timekeeper.Intermediaries
{
    public class WeaponAnimationToWeapon : MonoBehaviour
    {
        private Weapon weapon;

        private void Start()
        {
            weapon = GetComponentInParent<Weapon>();
        }

        private void AnimationFinishTrigger()
        {
            weapon.AnimationFinishTrigger();
        }

        private void AnimationStartMovementTrigger()
        {
            weapon.AnimationStartMovementTrigger();
        }

        private void AnimationStopMovementTrigger()
        {
            weapon.AnimationStopMovementTrigger();
        }

        private void AnimationTurnOffFlipTrigger()
        {
            weapon.AnimationTurnOffFlipTrigger();
        }

        private void AnimationTurnOnFlipTrigger()
        {
            weapon.AnimationTurnOnFlipTigger();
        }
        
        private void AnimationActionTrigger()
        {
            weapon.AnimationActionTrigger();
        }
    }
}