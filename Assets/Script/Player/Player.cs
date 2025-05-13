using System;
using UnityEngine;

public class Player : Entity
{
    [field:SerializeField] public PlayerInputs Inputs { get; private set; }

    private void OnEnable()
    {
        //Inputs.OnMovement += 
    }
}
