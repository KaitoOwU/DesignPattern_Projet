using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAttackFrame : MonoBehaviour
{
    
    [SerializeField] private List<Image> _frames = new(3);

    private void Reset()
    {
        foreach (Transform t in transform)
        {
            _frames.Add(t.GetComponent<Image>());
        }
    }

    public void AcquireAttack(AAttackType acquiredAttack)
    {
        for(int i = 0; i < _frames.Count; i++)
        {
            if (_frames[i] == null)
            {
                _frames[i].sprite = acquiredAttack.AttackSprite;
            }
        }
    }
}
