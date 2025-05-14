using System;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class EntityMovement : MonoBehaviour
{
    protected NavMeshAgent _agent;
    protected NavMeshSurface _navMesh;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _navMesh = FindFirstObjectByType<NavMeshSurface>();
    }

    public void ChangeNavMeshSurface(NavMeshSurface newNavMesh) => _navMesh = newNavMesh;
}
