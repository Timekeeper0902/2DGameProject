using Timekeeper.Weapons;
using UnityEngine;

namespace Timekeeper.Intermediaries
{
    public class WeaponHitboxToWeapon : MonoBehaviour
    {
        private AggressiveWeapon weapon;

        private void Awake()
        {
            weapon = GetComponentInParent<AggressiveWeapon>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            weapon.AddToDetected(collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            weapon.RemoveFromDetected(collision);
        }
    }
}