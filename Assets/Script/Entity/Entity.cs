using System;
using System.Collections.Generic;
using System.Linq;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour, IDamageable, IAttackUser
{

    [SerializeField] protected List<AAttackType> _attacks = new(); 
    [SerializeField] protected Transform _weaponPoint; 
    protected List<AAttackType> _instanciatedAttacks; 
    protected NavMeshSurface _ground;
    protected NavMeshAgent _agent;
    protected int _currentHealth;

    public List<AAttackType> Attacks => _attacks; 
    public Transform WeaponPoint => _weaponPoint;
    public int CurrentHealth => _currentHealth; 

    public void AcquireAttack(AAttackType newAttack)
    {
        if(_attacks.Any(a => a.AttackID == newAttack.AttackID)) return;
        _attacks.Add(newAttack);
        _instanciatedAttacks.Add(Instantiate(newAttack.gameObject, _weaponPoint).GetComponent<AAttackType>());
    }

    public void Damage(int damage, IAttackUser attacker)
    {
        _currentHealth -= damage;
        Debug.Log(damage);

        if (_currentHealth <= 0) 
        {
            foreach (var attack in _attacks) 
            { 
                attacker.AcquireAttack(attack);
            }
        }
    }

    protected virtual void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _ground = FindFirstObjectByType<NavMeshSurface>();

        foreach (AAttackType attack in _attacks)
            attack.OnAttackInit?.Invoke(this);
    }
}
