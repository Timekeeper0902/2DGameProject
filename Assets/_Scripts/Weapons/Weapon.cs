using System;
using UnityEngine;
using Timekeeper.CoreSystem;
using Timekeeper.ScriptableObjects.Weapons;
using Timekeeper.Utilities;

namespace Timekeeper.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] protected SO_WeaponData weaponData;

        protected Animator baseAnimator;
        protected Animator weaponAnimator;

        protected PlayerAttackState state;

        protected Core core;

        protected int attackCounter;

        protected float lastAttackTime;

        protected virtual void Awake()
        {
            baseAnimator = transform.Find("Base").GetComponent<Animator>();
            weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();

            gameObject.SetActive(false);
        }

        public virtual void EnterWeapon()
        {
            gameObject.SetActive(true);
            if(attackCounter >= weaponData.AmountOfAttacks)
            {
                attackCounter = 0;
            }
            //超过时间攻击变为第一段
            if(attackCounter >= 1 && (Time.time >= lastAttackTime + weaponData.attackHoldTime))
            {
                attackCounter = 0;
            }

            baseAnimator.SetBool("attack", true);
            weaponAnimator.SetBool("attack", true);

            baseAnimator.SetInteger("attackCounter", attackCounter);
            weaponAnimator.SetInteger("attackCounter", attackCounter);
        }

        public virtual void ExitWeapon()
        {
            baseAnimator.SetBool("attack", false);
            weaponAnimator.SetBool("attack", false);

            attackCounter++;
            lastAttackTime = Time.time;

            gameObject.SetActive(false);
        }

        #region Animation Triggers

        public virtual void AnimationFinishTrigger()
        {
            state.AnimationFinishTrigger();
        }

        public virtual void AnimationStartMovementTrigger()
        {
            state.SetPlayerVelocity(weaponData.MovementSpeed[attackCounter]);
        }

        public virtual void AnimationStopMovementTrigger()
        {
            state.SetPlayerVelocity(0f);
        }

        public virtual void AnimationTurnOffFlipTrigger()
        {
            state.SetFlipCheck(false);
        }

        public virtual void AnimationTurnOnFlipTigger()
        {
            state.SetFlipCheck(true);
        }

        public virtual void AnimationActionTrigger() { }

        #endregion

        public void InitializeWeapon(PlayerAttackState state, Core core)
        {
            this.state = state;
            this.core = core;
        }

    }
}