using System;
using UnityEngine;

[Serializable]
public class AttackFireball : AAttackType
{
    protected new const string _attackID = "AttackFireball";

    [SerializeField] private FireballAttackPool _fireballAttackPrefab;
    private FireballAttackPool _instantiatedFireballAttack;

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
        if(_instantiatedFireballAttack != null) 
            _instantiatedFireballAttack.LaunchFireball(target);
    }

    protected override void InitAttack(IAttackUser user)
    {
        _user = user;
        _instantiatedFireballAttack = Instantiate(_fireballAttackPrefab, transform.position, Quaternion.identity, transform).Init(this);
    }
}
