using System;
using UnityEngine;

[Serializable]
public class AttackMelee : AAttackType
{
    public override string AttackID { get => Constants.Attack_melee_id; }

    [SerializeField] MeleeWeapon _meleeWeapon;

    private void OnEnable()
    {
        OnAttackInit += InitAttack;
        _meleeWeapon.OnTrigger += OnTriggerAttack;
    }
    private void OnDisable()
    {
        OnAttackInit -= InitAttack;
        _meleeWeapon.OnTrigger -= OnTriggerAttack;
    }

    public override void ExecuteAttack(Vector3 target)
    {
        OnAttackExecuted?.Invoke(IAttackAnimationType.SWORD_SLASH);
        _attackAnimator.SetTrigger("Attack");
    }

    private void OnTriggerAttack(Collider other)
    {
        IAttackUser attackUser = other.GetComponentInParent<IAttackUser>();

        if (attackUser != null && attackUser == _user)
            return;

        IDamageable damageable = other.GetComponentInParent<IDamageable>();
        damageable?.Damage(_damage, _user);
    }


    protected override void InitAttack(IAttackUser user)
    {
        _user = user;
    }
}
