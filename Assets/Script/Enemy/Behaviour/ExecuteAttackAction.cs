using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Random = UnityEngine.Random;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ExecuteAttack", story: "Make the enemy attack the player", category: "Action", id: "3fe96635b970f0eba5cd3429a9ab4119")]
public partial class ExecuteAttackAction : Action
{

    private Entity _launchEntity;
    private Player _target;
    
    protected override Status OnStart()
    {
        _launchEntity = GameObject.GetComponent<Entity>();
        _target = UnityEngine.Object.FindFirstObjectByType<Player>();
        
        _launchEntity.Attacks[Random.Range(0, _launchEntity.Attacks.Count)].ExecuteAttack(_target.transform.position);
        
        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

