using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "IsPlayerInRange", story: "Check if the player is in range of [_detectionRange] from this enemy", category: "Conditions", id: "c43b462bd8131373997ae14ec177ba88")]
public partial class IsPlayerInRangeCondition : Condition
{
    [SerializeReference] public BlackboardVariable<float> DetectionRange;
    private Player _player;

    public override bool IsTrue()
    {
        return Vector3.Distance(_player.transform.position, this.GameObject.transform.position) <= DetectionRange;
    }

    public override void OnStart()
    {
        _player = UnityEngine.Object.FindFirstObjectByType<Player>();
    }

    public override void OnEnd()
    {
    }
}
