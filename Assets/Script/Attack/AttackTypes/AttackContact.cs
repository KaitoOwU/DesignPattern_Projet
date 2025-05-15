using System;
using UnityEngine;

[Serializable]
public class AttackContact : AAttackType
{
    private void OnEnable()
    {
        OnAttackInit += InitAttack;
    }
    private void OnDisable()
    {
        OnAttackInit -= InitAttack;
    }

    public override void ExecuteAttack(Vector3 target) {}

    protected override void InitAttack(){}

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = (IDamageable)collision;
        damageable?.Damage(_damage);
    }
}
