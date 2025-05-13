using System;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour
{

    protected NavMeshSurface _ground;
    protected NavMeshAgent _agent;

    protected virtual void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _ground = FindFirstObjectByType<NavMeshSurface>();
    }
}
