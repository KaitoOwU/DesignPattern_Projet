using System;
using UnityEngine;

[Serializable]
public class AttackMelee : AAttackType
{
    protected new const string _attackID = "AttackMelee";

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
        _attackAnimator.SetTrigger("MeleeAttack");
    }

    protected override void InitAttack(IAttackUser user)
    {
        _user = user;
    }
}
