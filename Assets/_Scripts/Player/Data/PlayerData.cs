using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName ="newPlayerData", menuName ="Data/Player Data/Base Data")]
[InlineEditor]
public class PlayerData : ScriptableObject
{
    protected const string PlayerBaseProperty= "玩家的基本移动属性";
    protected const string PlayerWallJumpProperty= "玩家的蹬墙跳属性";
    protected const string PlayerInAirProperty= "玩家的空中基本属性";
    protected const string PlayerWallSlideAndClimbProperty= "玩家的滑墙与爬墙属性";
    protected const string PlayerLedgeClimbPosProperty= "玩家的边缘攀爬开始与结束坐标";
    protected const string PlayerDashProperty= "玩家的冲刺相关属性";
    protected const string PlayerCrouchProperty= "玩家的蹲下属性";
    
    [FoldoutGroup("@PlayerBaseProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public float movementVelocity = 10f;
    [FoldoutGroup("@PlayerBaseProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public float jumpVelocity = 15f;
    [FoldoutGroup("@PlayerBaseProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public int amountOfJumps = 1;

    [FoldoutGroup("@PlayerWallJumpProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public float wallJumpVelocity = 20;
    [FoldoutGroup("@PlayerWallJumpProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public float wallJumpTime = 0.4f;
    [FoldoutGroup("@PlayerWallJumpProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public Vector2 wallJumpAngle = new Vector2(1, 2);

    [FoldoutGroup("@PlayerInAirProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public float coyoteTime = 0.2f;
    [FoldoutGroup("@PlayerInAirProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public float variableJumpHeightMultiplier = 0.5f;

    [FoldoutGroup("@PlayerWallSlideAndClimbProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public float wallSlideVelocity = 3f;
    [FoldoutGroup("@PlayerWallSlideAndClimbProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public float wallClimbVelocity = 3f;

    [FoldoutGroup("@PlayerLedgeClimbPosProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public Vector2 startOffset;
    [FoldoutGroup("@PlayerLedgeClimbPosProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public Vector2 stopOffset;

    [FoldoutGroup("@PlayerDashProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public float dashCooldown = 0.5f;
    [FoldoutGroup("@PlayerDashProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public float lastDashTime = -1f;
    [FoldoutGroup("@PlayerDashProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public float maxHoldTime = 1f;
    [FoldoutGroup("@PlayerDashProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public float holdTimeScale = 0.25f;
    [FoldoutGroup("@PlayerDashProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public float dashTime = 0.2f;
    [FoldoutGroup("@PlayerDashProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public float dashVelocity = 30f;
    [FoldoutGroup("@PlayerDashProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public float drag = 10f;
    [FoldoutGroup("@PlayerDashProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public float dashEndYMultiplier = 0.2f;
    [FoldoutGroup("@PlayerDashProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public float distBetweenAfterImages = 0.5f;

    [FoldoutGroup("@PlayerCrouchProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public float crouchMovementVelocity = 5f;
    [FoldoutGroup("@PlayerCrouchProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public float crouchColliderHeight = 0.8f;
    [FoldoutGroup("@PlayerCrouchProperty"), LabelWidth(100), GUIColor(0.1f, 1f, 0.1f)]
    public float standColliderHeight = 1.6f;

}
