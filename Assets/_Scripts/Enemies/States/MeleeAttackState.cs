using System.Collections;
using System.Collections.Generic;
using Timekeeper._Panel;
using Timekeeper.CoreSystem;
using Timekeeper.Enemies.Data;
using UnityEngine;

public class MeleeAttackState : AttackState {
	public MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, BaseAudioData baseAudioData, string animBoolName, Transform attackPosition, EnemyBaseData stateData) : base(entity, stateMachine, baseAudioData, animBoolName, attackPosition)
	{
		this.stateData = stateData;
	}

	private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
	private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }

	private Movement movement;
	private CollisionSenses collisionSenses;

	protected EnemyBaseData stateData;
	

	public override void DoChecks() {
		base.DoChecks();
	}

	public override void Enter() {
		base.Enter();
	}

	public override void Exit() {
		base.Exit();
	}

	public override void FinishAttack() {
		base.FinishAttack();
	}

	public override void LogicUpdate() {
		base.LogicUpdate();
	}

	public override void PhysicsUpdate() {
		base.PhysicsUpdate();
	}

	public override void TriggerAttack() {
		base.TriggerAttack();

		Collider2D[] detectedObjects = Physics2D.OverlapBoxAll(attackPosition.position, stateData.attackBoxArea, 0,stateData.whatIsPlayer);

		foreach (Collider2D collider in detectedObjects) {
			IDamageable damageable = collider.GetComponent<IDamageable>();

			if (damageable != null) {
				damageable.Damage(stateData.attackDamage);
			}

			IKnockbackable knockbackable = collider.GetComponent<IKnockbackable>();

			if (knockbackable != null) {
				knockbackable.Knockback(stateData.knockbackAngle, stateData.knockbackStrength, Movement.FacingDirection);
			}
		}
	}
}
