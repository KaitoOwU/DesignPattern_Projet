using System;
using UnityEngine;

public class Player : Entity
{
    public PlayerInputs Inputs { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        
        Inputs = GetComponent<PlayerInputs>();
    }

    private void OnEnable()
    {
        Inputs.OnMovement += MoveToMousePosition;
    }

    private void MoveToMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            _agent.SetDestination(hit.point);
        }
    }
}
