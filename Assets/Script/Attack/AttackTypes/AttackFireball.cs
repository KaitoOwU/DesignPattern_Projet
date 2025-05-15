using System;
using UnityEngine;

[Serializable]
public class AttackFireball : AAttackType
{
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

    protected override void InitAttack()
    {
        _instantiatedFireballAttack = Instantiate(_fireballAttackPrefab, _weaponPoint.position, Quaternion.identity, _weaponPoint).Init(this);
    }
}
