using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private Inputs _inputs;
    
    public Action OnMovement;

#region Attack Actions

    public Action OnAutoAttack;
    public Action OnSpecialAttack1;
    public Action OnSpecialAttack2;
    public Action OnSpecialAttack3;

#endregion

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
        Debug.Log("Left Click");
        OnMovement?.Invoke();
    }

    private void OnAutoAttackInputStarted(InputAction.CallbackContext obj)
    {
        Debug.Log("Right Click");
        OnAutoAttack?.Invoke();
    }

    private void OnAttack1InputStarted(InputAction.CallbackContext obj)
    {
        Debug.Log("A");
        OnSpecialAttack1?.Invoke();
    }

    private void OnAttack2InputStarted(InputAction.CallbackContext obj)
    {
        Debug.Log("Z");
        OnSpecialAttack2?.Invoke();
    }

    private void OnAttack3InputStarted(InputAction.CallbackContext obj)
    {
        Debug.Log("E");
        OnSpecialAttack3?.Invoke();
    }
    
    #endregion
}
