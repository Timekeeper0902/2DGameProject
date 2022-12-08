using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState {
	public bool CanDash { get; private set; }
	private bool _isHolding;
	private bool _dashInputStop;

	private Vector2 _dashDirection;
	private Vector2 _dashDirectionInput;
	private Vector2 _lastAIPos;

	public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName) {
	}
	public override void Enter() {
		base.Enter();

		CanDash = false;
		player.InputHandler.UseDashInput();

		_isHolding = true;
		_dashDirection = Vector2.right * Movement.FacingDirection;

		Time.timeScale = playerData.holdTimeScale;
		startTime = Time.unscaledTime;

		player.DashDirectionIndicator.gameObject.SetActive(true);

	}

	public override void Exit() {
		base.Exit();

		if (Movement?.CurrentVelocity.y > 0) {
			Movement?.SetVelocityY(Movement.CurrentVelocity.y * playerData.dashEndYMultiplier);
		}
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		if (!isExitingState) {

			player.Anim.SetFloat("yVelocity", Movement.CurrentVelocity.y);
			player.Anim.SetFloat("xVelocity", Mathf.Abs(Movement.CurrentVelocity.x));


			if (_isHolding) {
				_dashDirectionInput = player.InputHandler.DashDirectionInput;
				_dashInputStop = player.InputHandler.DashInputStop;

				if (_dashDirectionInput != Vector2.zero) {
					_dashDirection = _dashDirectionInput;
					_dashDirection.Normalize();
				}

				float angle = Vector2.SignedAngle(Vector2.right, _dashDirection);
				player.DashDirectionIndicator.rotation = Quaternion.Euler(0f, 0f, angle - 45f);

				if (_dashInputStop || Time.unscaledTime >= startTime + playerData.maxHoldTime) {
					_isHolding = false;
					Time.timeScale = 1f;
					startTime = Time.time;
					Movement?.CheckIfShouldFlip(Mathf.RoundToInt(_dashDirection.x));
					player.RB.drag = playerData.drag;
					Movement?.SetVelocity(playerData.dashVelocity, _dashDirection);
					player.DashDirectionIndicator.gameObject.SetActive(false);
					PlaceAfterImage();
				}
			} else {
				Movement?.SetVelocity(playerData.dashVelocity, _dashDirection);
				CheckIfShouldPlaceAfterImage();

				if (Time.time >= startTime + playerData.dashTime) {
					player.RB.drag = 0f;
					isAbilityDone = true;
					playerData.lastDashTime = Time.time;
				}
			}
		}
	}

	private void CheckIfShouldPlaceAfterImage() {
		if (Vector2.Distance(player.transform.position, _lastAIPos) >= playerData.distBetweenAfterImages) {
			PlaceAfterImage();
		}
	}

	private void PlaceAfterImage() {
		PlayerAfterImagePool.Instance.GetFromPool();
		_lastAIPos = player.transform.position;
	}

	public bool CheckIfCanDash() {
		return CanDash && Time.time >= playerData.lastDashTime + playerData.dashCooldown;
	}

	public void ResetCanDash() => CanDash = true;

}
