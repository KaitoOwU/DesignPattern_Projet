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
    protected List<AAttackType> _instanciatedAttacks = new(); 
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
        _instanciatedAttacks.Add(Instantiate(newAttack.gameObject, Vector3.zero, Quaternion.identity, _weaponPoint).GetComponent<AAttackType>());
    }

    public void Damage(int damage, IAttackUser attacker)
    {
        _currentHealth -= damage;
        Debug.Log($"Damage {damage}");

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
        {
            if(attack == null) continue;
            _instanciatedAttacks.Add(Instantiate(attack.gameObject, Vector3.zero, Quaternion.identity).GetComponent<AAttackType>());
            _instanciatedAttacks[^1].transform.SetParent(WeaponPoint.transform, false);
            _instanciatedAttacks[^1].OnAttackInit?.Invoke(this);
        }
    }
}
