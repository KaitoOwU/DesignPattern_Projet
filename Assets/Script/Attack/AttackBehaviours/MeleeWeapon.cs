using System;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class MeleeWeapon : MonoBehaviour
{

    public Action<Collider> OnTrigger;


    private void OnTriggerEnter(Collider other)
    {
        OnTrigger?.Invoke(other);
    }


}
