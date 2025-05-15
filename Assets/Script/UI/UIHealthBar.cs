using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private List<Image> _hearts = new();

    private void Reset()
    {
        _hearts = GetComponentsInChildren<Image>().ToList();
    }
}
