using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIAttackFrame : MonoBehaviour
{
    
    [SerializeField] private List<Image> _frames = new(3);

    private void Reset()
    {
        foreach (Transform t in transform)
        {
            _frames.Add(t.GetChild(0).GetComponent<Image>());
        }
    }

    public void AcquireAttack(int index, AAttackType acquiredAttack)
    {
        _frames[index].sprite = acquiredAttack.AttackSprite;
        _frames[index].DOFade(1f, 0.5f);
    }
}
