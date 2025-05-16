using System;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [field:SerializeField] public UIAttackFrame AttackFrame { get; private set; }
    [field:SerializeField] public UIHealthBar HealthBar { get; private set; }

    private void Reset()
    {
        AttackFrame = GetComponentInChildren<UIAttackFrame>();
        HealthBar = GetComponentInChildren<UIHealthBar>();
    }
}
