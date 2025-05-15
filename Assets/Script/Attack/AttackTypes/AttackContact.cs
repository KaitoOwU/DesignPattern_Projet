using System;
using UnityEngine;

[Serializable]
public class AttackContact : AAttackType
{
    public override string AttackID { get => Constants.Attack_contact_id; }

    private void OnEnable()
    {
        OnAttackInit += InitAttack;
    }
    private void OnDisable()
    {
        OnAttackInit -= InitAttack;
    }

    public override void ExecuteAttack(Vector3 target) {}

    private void OnTriggerEnter(Collider other)
    {
        IAttackUser attackUser = other.GetComponent<IAttackUser>();

        if (attackUser != null && attackUser == _user)
            return;

        IDamageable damageable = other.GetComponent<IDamageable>();
        damageable?.Damage(_damage, _user);
    }

    protected override void InitAttack(IAttackUser user)
    {
        _user = user;
    }
}
