using System;
using UnityEngine;

[Serializable]
public class AttackMelee : AAttackType
{
    public override string AttackID { get => Constants.Attack_melee_id; }

    [SerializeField] GameObject _meleeAttackPrefab;

    private void OnEnable()
    {
        OnAttackInit += InitAttack;
    }
    private void OnDisable()
    {
        OnAttackInit -= InitAttack;
    }

    public override void ExecuteAttack(Vector3 target)
    {
        OnAttackExecuted?.Invoke(IAttackAnimationType.SWORD_SLASH);
    }

    protected override void InitAttack(IAttackUser user)
    {
        _user = user;
    }
}
