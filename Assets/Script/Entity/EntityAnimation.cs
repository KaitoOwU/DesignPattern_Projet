using System;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class EntityAnimation : MonoBehaviour
{
    private static readonly int WALK_SPEED = Animator.StringToHash("WalkSpeed");
    
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;

    [SerializeField] private AnimatorController _animatorController;

    private void Reset()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Awake()
    {
        _animator.runtimeAnimatorController = _animatorController;
    }

    private void Update()
    {
        _animator.SetFloat(WALK_SPEED, _agent.velocity.magnitude);
    }
}
