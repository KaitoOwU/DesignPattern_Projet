using System;
using UnityEngine;

[Serializable]
public class AttackSword : AAttackType
{
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
        throw new System.NotImplementedException();
    }

    protected override void InitAttack()
    {
        throw new NotImplementedException();
    }
}
