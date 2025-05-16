using System;
using UnityEngine;

[Serializable]
public class AttackFireball : AAttackType
{
    public override string AttackID { get => Constants.Attack_fireball_id; }

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
        OnAttackExecuted?.Invoke(IAttackAnimationType.SPELL_CAST);
        
        if(_instantiatedFireballAttack != null) 
            _instantiatedFireballAttack.LaunchFireball(target);
    }

    protected override void InitAttack(IAttackUser user)
    {
        _user = user;
        _instantiatedFireballAttack = Instantiate(_fireballAttackPrefab, Vector3.zero, Quaternion.identity, transform).Init(this);
    }
}
