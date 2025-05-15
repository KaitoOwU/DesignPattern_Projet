using System;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour, IDamageable, IAttackUser
{

    [Header("Datas")]
    [SerializeField] protected List<AAttackType> _attacks;
    [SerializeField] protected int _currentHealth;
    protected NavMeshSurface _ground;
    protected NavMeshAgent _agent;

    public event Action<int> OnHealthChanged;

    public int CurrentHealth { get => _currentHealth; }
    public List<AAttackType> Attacks { get => _attacks; } 

    public void Damage(int damage)
    {
        _currentHealth -= damage;
        OnHealthChanged?.Invoke(_currentHealth);
    }

    protected virtual void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _ground = FindFirstObjectByType<NavMeshSurface>();

        foreach (AAttackType attack in _attacks)
            attack.OnAttackInit.Invoke();
    }

}
