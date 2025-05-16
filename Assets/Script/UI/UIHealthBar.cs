using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private List<UIHeartContainer> _hearts = new();
    [SerializeField] private Player _player;

    private void Reset()
    {
        foreach (Transform t in transform)
        {
            _hearts.Add(t.GetComponent<UIHeartContainer>());
        }
        _player = FindFirstObjectByType<Player>();
    }

    private void Awake()
    {
        for (int i = 1; i < _player.CurrentHealth; i++)
        {
            _hearts.Add(Instantiate(_hearts[0], _hearts[0].transform.parent));
        }
    }

    private void OnEnable()
    {
        _player.OnHealthChanged += UpdateHealth;
    }

    private void OnDisable()
    {
        _player.OnHealthChanged -= UpdateHealth;
    }

    private void UpdateHealth(int newHealth)
    {
        if (newHealth < 0) return;
        _hearts[newHealth].SetActive(false);
    }
}
