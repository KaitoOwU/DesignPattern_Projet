using System;
using UnityEngine;

[Serializable]
public class AttackSword : AAttackType
{
    public override string AttackID { get => Constants.Attack_sword_id;}

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
        OnAttackExecuted?.Invoke(IAttackAnimationType.SWORD_SLASH);
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, (target - transform.position).normalized, out hit, _range))
        {
            Debug.DrawRay(transform.position, (target - transform.position).normalized * _range, Color.magenta, 3);
            IAttackUser attackUser = hit.transform.GetComponent<IAttackUser>();

            if (attackUser != null && attackUser == _user)
                return;

            IDamageable damageable = hit.transform.GetComponent<IDamageable>();
            damageable?.Damage(_damage, _user);
        }
    }

    protected override void InitAttack(IAttackUser user)
    {
        _user = user;
    }
}
