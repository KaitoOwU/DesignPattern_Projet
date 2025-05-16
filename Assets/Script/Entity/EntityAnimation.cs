using System;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class EntityAnimation : MonoBehaviour
{
    public static readonly int WALK_SPEED = Animator.StringToHash("WalkSpeed");
    public static readonly int ANIM_SLASH = Animator.StringToHash("Sword_Slash");
    public static readonly int ANIM_SPELL = Animator.StringToHash("Spellcast_Shoot");
    
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;

    [SerializeField] private AnimatorController _animatorController;

    public Animator Animator => _animator;
    
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

public enum IAttackAnimationType
{
    NONE,
    SWORD_SLASH,
    SPELL_CAST
}
