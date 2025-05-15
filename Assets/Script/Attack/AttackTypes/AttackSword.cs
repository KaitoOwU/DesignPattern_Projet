using System;
using UnityEngine;

[Serializable]
public class AttackSword : AAttackType
{
    protected new const string _attackID = "AttackSword";

    [SerializeField, Range(0.5f, 5.0f)] private float _range;

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
        RaycastHit hit;
        if (Physics.Raycast(transform.position, (target - transform.position).normalized, out hit, _range))
        {
            IAttackUser attackUser = (IAttackUser)hit.transform;
            if (attackUser != null && attackUser == _user)
                return;
            IDamageable damageable = (IDamageable)hit.transform;
            damageable?.Damage(_damage, _user);
        }
    }

    protected override void InitAttack(IAttackUser user)
    {
        _user = user;
    }
}
