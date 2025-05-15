using System;
using UnityEngine;

[Serializable]
public abstract class AAttackType : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [SerializeField] protected Animator _attackAnimator;

    protected IAttackUser _user;
    
    public Action<IAttackUser> OnAttackInit;

    public abstract string AttackID { get;}
    public int Damage => _damage;
    public IAttackUser User => _user;

    protected abstract void InitAttack(IAttackUser user);
    public abstract void ExecuteAttack(Vector3 target);
}
