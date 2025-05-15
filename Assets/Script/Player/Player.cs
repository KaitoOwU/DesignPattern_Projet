using System;
using UnityEngine;

public class Player : Entity
{
    [field:SerializeField] public PlayerInputs Inputs { get; private set; }
    [field:SerializeField] public PlayerMovement Movements { get; private set; }

    private void Reset()
    {
        Inputs = GetComponent<PlayerInputs>();
        Movements = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        Inputs.OnMovement += Movements.MoveToMousePosition;
        //TODO: CONNECTER LES ATTAQUES
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            this.Damage(1);
        }
    }
}
