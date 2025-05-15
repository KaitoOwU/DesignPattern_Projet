using UnityEngine;

public interface IDamageable
{
    int CurrentHealth { get; }

    void GetDamage(int damage);
}
