using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Fireball : MonoBehaviour
{
    public bool IsUsed {  get; private set; }
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _maxLifeTime = 4;
    private AAttackType _attackRef;
    private bool _canMove;
    private Vector3 _moveDir = Vector3.zero;
    private Transform _parent;

    public Fireball Init(AAttackType attackRef)
    {
        _attackRef = attackRef;
        return this;
    }

    private void Update()
    {
        if (_canMove)
        {
            transform.position += _moveDir * (Time.deltaTime * _speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IAttackUser attackUser = other.GetComponent<IAttackUser>();
        if (attackUser != null && attackUser == _attackRef.User)
            return;

        IDamageable damageable = other.GetComponent<IDamageable>();
        if(damageable != null)
        {
            damageable?.Damage(_attackRef.Damage, _attackRef.User);
            DisableFireball();
        }
    }

    public void EnableFireball(Vector3 dir)
    {
        _parent = transform.parent;
        _canMove = true;
        IsUsed = true;
        _moveDir = new Vector3(dir.x, 0, dir.z);
        transform.SetParent(null, true);
        StartCoroutine(WaitForStop());
    }

    IEnumerator WaitForStop()
    {
        yield return new WaitForSeconds(_maxLifeTime);
        if (IsUsed)
            DisableFireball();
    }


    private void DisableFireball()
    {
        _canMove = false;
        _moveDir = Vector3.zero;
        transform.position = Vector3.zero;
        transform.SetParent(_parent, false);
        transform.localPosition = Vector3.zero;
        IsUsed = false;
        gameObject.SetActive(false);
    }
}
