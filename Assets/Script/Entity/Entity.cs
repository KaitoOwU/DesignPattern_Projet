using System;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour, IDamageable, IAttackUser
{

    protected NavMeshSurface _ground;
    protected NavMeshAgent _agent;
    [SerializeField] protected List<AAttackType> _attacks; 
    protected int _currentHealth;

    public int CurrentHealth { get => _currentHealth; }
    public List<AAttackType> Attacks { get => _attacks; } 

    public void GetDamage(int damage)
    {
        _currentHealth -= damage;
    }

    protected virtual void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _ground = FindFirstObjectByType<NavMeshSurface>();

        foreach (AAttackType attack in _attacks)
            attack.OnAttackInit.Invoke();
    }

}
