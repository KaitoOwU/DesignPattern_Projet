using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Fireball : MonoBehaviour
{
    public bool IsUsed {  get; private set; }
    [SerializeField] private float _speed;
    private Animator _animator;
    private AAttackType _attackRef;
    private bool _isMoving;
    private Vector3 _moveDir = Vector3.zero;

    public Fireball Init(AAttackType attackRef)
    {
        _attackRef = attackRef;
        return this;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_isMoving)
        {
            transform.Translate(_moveDir * Time.deltaTime * _speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IAttackUser attackUser = (IAttackUser)other;
        if (attackUser != null && attackUser == _attackRef.User)
            return;
        IDamageable damageable = (IDamageable)other;
        damageable?.Damage(_attackRef.Damage, _attackRef.User);
        StartCoroutine(DisableFireball());
    }

    public void EnableFireball(Vector2 dir)
    {
        IsUsed = true;
        _moveDir = dir;
    }

    IEnumerator DisableFireball()
    {
        _isMoving = false;
        if (_animator != null)
            _animator.SetTrigger("Explode");
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length);
        IsUsed = false;
        _moveDir = Vector3.zero;
        transform.position = transform.parent.position;
        gameObject.SetActive(false);
    }
}
