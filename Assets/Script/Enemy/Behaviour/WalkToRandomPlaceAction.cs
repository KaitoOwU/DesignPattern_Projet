using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Random = UnityEngine.Random;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "WalkToRandomPlace", story: "Walk to random place in range [_randomRange] meters", category: "Action", id: "5114a0c3b812b31259d55494dbe06325")]
public partial class WalkToRandomPlaceAction : Action
{
    [SerializeReference] public BlackboardVariable<float> RandomRange;
    private EntityMovement _movement;
    private Vector3 _destination;

    protected override Status OnStart()
    {
        if (!GameObject.TryGetComponent(out _movement))
            return Status.Failure;

        _destination = GameObject.transform.position +
                       Random.Range(-RandomRange.Value / 2f, RandomRange.Value / 2f) * GameObject.transform.forward +
                       Random.Range(-RandomRange.Value / 2f, RandomRange.Value / 2f) * GameObject.transform.right;
        _movement.NavigateTo(_destination);
            
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return _movement.DistanceApartDestination() <= 0.1f ? Status.Success : Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

