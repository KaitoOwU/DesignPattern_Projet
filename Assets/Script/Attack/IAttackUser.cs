using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackUser
{
    List<AAttackType> Attacks { get;}
    Transform WeaponPoint { get; }

    void AcquireAttack(AAttackType newAttack);

}
