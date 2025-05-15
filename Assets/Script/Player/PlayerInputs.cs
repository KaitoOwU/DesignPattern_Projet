using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private Inputs _inputs;
    
    public Action OnMovement;

    private void Awake()
    {
        _inputs = new();
    }

    private void OnEnable()
    {
        _inputs.Player.Movement.started += OnMovementInputStarted;
        _inputs.Player.AutoAttack.started += OnAutoAttackInputStarted;
        _inputs.Player.Attack1.started += OnAttack1InputStarted;
        _inputs.Player.Attack2.started += OnAttack2InputStarted;
        _inputs.Player.Attack3.started += OnAttack3InputStarted;
        
        _inputs.Enable();
    }

    private void OnDisable()
    {
        _inputs.Player.Movement.started -= OnMovementInputStarted;
        _inputs.Player.AutoAttack.started -= OnAutoAttackInputStarted;
        _inputs.Player.Attack1.started -= OnAttack1InputStarted;
        _inputs.Player.Attack2.started -= OnAttack2InputStarted;
        _inputs.Player.Attack3.started -= OnAttack3InputStarted;

        _inputs.Disable();
    }

    #region Inputs Functions
    
    private void OnMovementInputStarted(InputAction.CallbackContext obj)
    {
        OnMovement?.Invoke();
    }

    private void OnAutoAttackInputStarted(InputAction.CallbackContext obj)
    {
    }

    private void OnAttack1InputStarted(InputAction.CallbackContext obj)
    {
    }

    private void OnAttack2InputStarted(InputAction.CallbackContext obj)
    {
    }

    private void OnAttack3InputStarted(InputAction.CallbackContext obj)
    {
    }
    
    #endregion
}
