using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIHeartContainer : MonoBehaviour
{
    [SerializeField] private Image _heart;
    [SerializeField] private Image _heartContainer;
    
    public bool IsActive { get; private set; }

    private void Reset()
    {
        _heartContainer = GetComponent<Image>();
        _heart = transform.GetChild(0).GetComponent<Image>();
    }

    public void SetActive(bool state)
    {
        _heart.DOFade(state ? 1f : 0f, .75f);
        IsActive = state;
    }
}
