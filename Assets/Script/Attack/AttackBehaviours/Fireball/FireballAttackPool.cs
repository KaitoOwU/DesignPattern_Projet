using System;
using System.Collections.Generic;
using UnityEngine;

public class FireballAttackPool : MonoBehaviour
{
    [SerializeField] private Fireball _fireballPrefab;
    [SerializeField, Range(3,15)] private int _poolSize;
    [SerializeField] private Transform _poolParent;
    private List<Fireball> _fireballPool;

    public FireballAttackPool Init(AAttackType attackRef)
    {
        for (int i = 0; i < _poolSize; i++) {
            Fireball fireball = Instantiate(_fireballPrefab, _poolParent.position, Quaternion.identity, _poolParent).Init(attackRef);
            fireball.gameObject.SetActive(false);
            _fireballPool.Add(fireball);
        }
        return this;
    }

    public void LaunchFireball(Vector3 target)
    {
        Fireball fireball = GetNextItemInPool();
        if (fireball != null)
        {
            fireball.gameObject.SetActive(true);
            fireball.EnableFireball((target - transform.position).normalized);
        }
    }

    private Fireball GetNextItemInPool()
    {
        foreach (Fireball fireball in _fireballPool)
        {
            if(!fireball.IsUsed)
                return fireball;
        }
        return null;
    }
}
