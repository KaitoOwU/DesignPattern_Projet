using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAttackFrame : MonoBehaviour
{

    [SerializeField] private List<Image> _frames = new();

    private void Reset()
    {
        foreach (Transform t in transform)
        {
            _frames.Add(t.GetComponent<Image>());
        }
    }
}
