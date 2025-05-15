using UnityEngine;

public interface IDamageable
{
    int CurrentHealth { get; }

    void Damage(int damage);
}
