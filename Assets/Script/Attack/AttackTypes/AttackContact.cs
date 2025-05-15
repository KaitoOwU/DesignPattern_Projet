using System;
using UnityEngine;

[Serializable]
public class AttackContact : AAttackType
{
    protected new const string _attackID = "AttackContact";

    private void OnEnable()
    {
        OnAttackInit += InitAttack;
    }
    private void OnDisable()
    {
        OnAttackInit -= InitAttack;
    }

    public override void ExecuteAttack(Vector3 target) {}

    private void OnTriggerEnter(Collider collision)
    {
        IAttackUser attackUser = (IAttackUser)collision;
        if (attackUser != null && attackUser == _user)
            return;
        
        IDamageable damageable = (IDamageable)collision;
        damageable?.Damage(_damage, _user);
    }

    protected override void InitAttack(IAttackUser user)
    {
        _user = user;
    }
}
