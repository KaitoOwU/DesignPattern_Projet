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

    public void AcquireAttack(AAttackType acquiredAttack)
    {
        int index = -1;
        switch (acquiredAttack.AttackID)
        {
            case Constants.Attack_melee_id:
                index = 0;
                _frames[0].sprite = acquiredAttack.AttackSprite;
                break;
            
            case Constants.Attack_fireball_id:
                index = 1;
                _frames[1].sprite = acquiredAttack.AttackSprite;
                break;
            
            case Constants.Attack_contact_id:
                index = 2;
                _frames[2].sprite = acquiredAttack.AttackSprite;
                break;
            
            default:
                return;
        }

        if (index < 0)
            return;

        _frames[index].sprite = acquiredAttack.AttackSprite;
        _frames[index].DOFade(1f, 0.5f);
    }
}
