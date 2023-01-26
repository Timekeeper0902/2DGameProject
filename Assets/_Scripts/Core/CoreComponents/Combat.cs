using System;
using UnityEngine;
using UnityEngine.UI;

namespace Timekeeper.CoreSystem
{
	public class Combat : CoreComponent, IDamageable, IKnockbackable
	{

		[SerializeField] private GameObject damageParticles;
		public GameObject floatPoint;
		public Image enemyBloodBar;
		private Image bloodBar;
		private Image blood;
		private Canvas _canvas;
	
		private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
		private CollisionSenses CollisionSenses {
			get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses);
		}
		private Stats Stats { get => _stats ?? core.GetCoreComponent(ref _stats); }
		private ParticleManager ParticleManager => particleManager ? particleManager : core.GetCoreComponent(ref particleManager);
	
		private Movement movement;
		private CollisionSenses collisionSenses;
		private Stats _stats;
		private ParticleManager particleManager;

		[SerializeField] private float maxKnockbackTime = 0.2f;

		private bool isKnockbackActive;
		private float knockbackStartTime;

		private void Start()
		{
			
		}

		public override void LogicUpdate() {
			CheckKnockback();
			//CheckBloodBar();
		}

		public void Damage(float amount) {
			Debug.Log(core.transform.parent.name + " Damaged!");
			Stats?.DecreaseHealth(amount);
			GameObject gb = Instantiate(floatPoint,transform.position,Quaternion.identity) as GameObject;
			gb.transform.GetChild(0).GetComponent<TextMesh>().text = amount.ToString();

			// if (core.transform.parent.CompareTag("Enemy"))
			// {
			// 	enemyBloodBar.gameObject.SetActive(true);
			// 	blood.fillAmount = _stats.CurrentHealth / _stats.maxHealth;
			// }
			
			ParticleManager?.StartParticlesWithRandomRotation(damageParticles);
		}

		public void Knockback(Vector2 angle, float strength, int direction) {
			Movement?.SetVelocity(strength, angle, direction);
			Movement.CanSetVelocity = false;
			isKnockbackActive = true;
			knockbackStartTime = Time.time;
		}

		private void CheckKnockback() {
			if (isKnockbackActive
			    && ((Movement?.CurrentVelocity.y <= 0.01f && CollisionSenses.Ground)
			        || Time.time >= knockbackStartTime + maxKnockbackTime)
			   ) {
				isKnockbackActive = false;
				Movement.CanSetVelocity = true;
			}
		}

		// private void CheckBloodBar()
		// {
		// 	if (core.transform.parent.CompareTag("Enemy"))
		// 	{
		// 		Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
		// 		enemyBloodBar.transform.position = new Vector3(screenPos.x,screenPos.y + 20);
		// 		blood.transform.position = new Vector3(screenPos.x,screenPos.y + 20);
		// 	}
		// 	
		// }
	}
}
