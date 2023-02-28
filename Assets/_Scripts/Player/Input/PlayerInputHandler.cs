using System;
using System.Collections;
using System.Collections.Generic;
using Timekeeper;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerInputHandler : Singleton<PlayerInputHandler>
{
    private PlayerInput playerInput;
    private Camera cam;

    public Vector2 RawMovementInput { get; private set; }
    public Vector2 RawDashDirectionInput { get; private set; }
    public Vector2Int DashDirectionInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public int DashInputX { get; private set; }
    public int DashInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool GrabInput { get; private set; }
    public bool DashInput { get; private set; }
    public bool DashInputStop { get; private set; }
    public bool EscInput { get; private set; }
    public bool ActiveInput { get; private set; }
    public int SpaceInput { get; private set; }

    public bool[] AttackInputs { get; private set; }

    [SerializeField]
    private float inputHoldTime = 0.2f;

    private float _jumpInputStartTime;
    private float _dashInputStartTime;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        int count = Enum.GetValues(typeof(CombatInputs)).Length;
        AttackInputs = new bool[count];

        cam = Camera.main;
    }

    private void Update()
    {
        CheckJumpInputHoldTime();
        CheckDashInputHoldTime();
    }

    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.primary] = true;
        }

        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.primary] = false;
        }
    }

    public void OnSecondaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.secondary] = true;
        }

        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.secondary] = false;
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormInputY = Mathf.RoundToInt(RawMovementInput.y);       
        
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputStop = false;
            _jumpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            JumpInputStop = true;
        }
    }

    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GrabInput = true;
        }

        if (context.canceled)
        {
            GrabInput = false;
        }
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DashInput = true;
            DashInputStop = false;
            _dashInputStartTime = Time.time;
        }
        else if (context.canceled)
        {
            DashInputStop = true;
        }
    }

    public void OnDashDirectionInput(InputAction.CallbackContext context)
    {
        RawDashDirectionInput = context.ReadValue<Vector2>();

        if(playerInput.currentControlScheme == "Keyboard")
        {
            DashInputX = Mathf.RoundToInt(RawDashDirectionInput.x);
            DashInputY = Mathf.RoundToInt(RawDashDirectionInput.y);
        }

        DashDirectionInput = Vector2Int.RoundToInt(RawDashDirectionInput.normalized);
    }

    public void UseJumpInput() => JumpInput = false;

    public void UseDashInput() => DashInput = false;

    private void CheckJumpInputHoldTime()
    {
        if(Time.time >= _jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }

    private void CheckDashInputHoldTime()
    {
        if(Time.time >= _dashInputStartTime + inputHoldTime)
        {
            DashInput = false;
        }
    }
    
    public void OnEscInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            
        }
        
        if (context.canceled)
        {
            EscInput = !EscInput;
        }
    }
    
    public void OnActiveInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ActiveInput = true;
        }
        
        if (context.canceled)
        {
            ActiveInput = false;
        }
    }
    
    public void OnSpaceInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            
        }
        
        if (context.canceled)
        {
            SpaceInput++;
        }
    }

    public void SetSpaceInputZero()
    {
        SpaceInput = 0;
    }
}

public enum CombatInputs
{
    primary,
    secondary
}
