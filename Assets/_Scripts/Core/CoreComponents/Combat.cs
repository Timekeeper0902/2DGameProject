using UnityEngine;

namespace Timekeeper.CoreSystem
{
	public class Combat : CoreComponent, IDamageable, IKnockbackable
	{

		[SerializeField] private GameObject damageParticles;
		public GameObject floatPoint;
	
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

		public override void LogicUpdate() {
			CheckKnockback();
		}

		public void Damage(float amount) {
			Debug.Log(core.transform.parent.name + " Damaged!");
			Stats?.DecreaseHealth(amount);
			GameObject gb = Instantiate(floatPoint,transform.position,Quaternion.identity) as GameObject;
			gb.transform.GetChild(0).GetComponent<TextMesh>().text = amount.ToString(); 

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
	}
}
