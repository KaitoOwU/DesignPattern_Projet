using System;
using System.Linq;
using UnityEngine;

public class Player : Entity
{
    [field:SerializeField] public PlayerInputs Inputs { get; private set; }
    [field:SerializeField] public PlayerMovement Movements { get; private set; }
    [field:SerializeField] public MainUI MainUI { get; private set; }

    private void Reset()
    {
        Inputs = GetComponent<PlayerInputs>();
        Movements = GetComponent<PlayerMovement>();
        MainUI = FindFirstObjectByType<MainUI>();
    }

    protected override void Awake()
    {
        base.Awake();
        _attacks.ForEach(SetupAttackUI);
    }

    private void OnEnable()
    {
        Inputs.OnMovement += Movements.MoveToMousePosition;
        
        Inputs.OnAutoAttack += AutoAttack;
        Inputs.OnSpecialAttack1 += SpecialAttack1;
        Inputs.OnSpecialAttack2 += SpecialAttack2;
        Inputs.OnSpecialAttack3 += SpecialAttack3;
    }

    public override void AcquireAttack(AAttackType newAttack)
    {
        base.AcquireAttack(newAttack);
        SetupAttackUI(newAttack);
    }

    private void SetupAttackUI(AAttackType attack)
    {
        MainUI.AttackFrame.AcquireAttack(_attacks.IndexOf(attack), attack);
    }

    #region Attack Setup

    private void AutoAttack()
    {
        ExecuteAttackByID(Constants.Attack_sword_id);
    }    

    private void SpecialAttack1()
    {
        ExecuteAttackByID(Constants.Attack_melee_id);
    }

    private void SpecialAttack2()
    {
        ExecuteAttackByID(Constants.Attack_fireball_id);
    }

    private void SpecialAttack3()
    {
        ExecuteAttackByID(Constants.Attack_contact_id);
    }

    private void ExecuteAttackByID(string id)
    {
        var attack = _instanciatedAttacks.FirstOrDefault(x => x.AttackID == id);

        if (attack != null)
        {
            var target = GetTargetMousePosition();
            if (target != null)
            {
                attack.ExecuteAttack((Vector3)target);
                Debug.Log($"Player Execute Attack : {id}");
            }
        }
    }

    private Vector3? GetTargetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return null;
    }
#endregion

}
