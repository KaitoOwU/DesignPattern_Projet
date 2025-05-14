using System;
using System.Numerics;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

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

    public void NavigateTo(Vector3 position)
    {
        _agent.SetDestination(position);
    }

    public float DistanceApartDestination()
    {
        float dis = Vector3.Distance(this.transform.position, _agent.destination);
        Debug.Log(dis);
        return dis;
    }
        
}
