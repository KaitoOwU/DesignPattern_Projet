using System;
using UnityEngine;

[Serializable]
public abstract class AAttackType : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [SerializeField] protected Transform _weaponPoint;
    [SerializeField] protected Animator _attackAnimator;
    public Action OnAttackInit;

    public int Damage => _damage;

    protected abstract void InitAttack();
    public abstract void ExecuteAttack(Vector3 target);
}
