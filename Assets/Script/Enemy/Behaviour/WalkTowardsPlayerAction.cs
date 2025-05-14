using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "WalkTowardsPlayer", story: "Walk towards player and stop when in distance of [_distance] meters from player", category: "Action", id: "958b6cd406d95c1aa7eea43bc747a1b8")]
public partial class WalkTowardsPlayerAction : Action
{
    [SerializeReference] public BlackboardVariable<float> Distance;
    private Player _player;
    private EntityMovement _movement;

    protected override Status OnStart()
    {
        _player = UnityEngine.Object.FindFirstObjectByType<Player>();
        
        _movement = GameObject.GetComponent<EntityMovement>();
        _movement.NavigateTo(_player.transform.position);
        
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        _movement.NavigateTo(_player.transform.position);
        return _movement.DistanceApartDestination() <= Distance.Value ? Status.Success : Status.Running;
    }

    protected override void OnEnd()
    {
        _movement.NavigateTo(_movement.transform.position);
    }
}

