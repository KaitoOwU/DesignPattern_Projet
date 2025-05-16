using UnityEngine;
using Unity.Behavior;

public class Enemy : Entity
{
    protected override void Die()
    {
        Destroy(GetComponent<BehaviorGraphAgent>());
        base.Die();
    }
}
