using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _lifeTime;

    private WaitForSeconds _waitForSeconds;
    private Vector3 _direction = Vector3.zero;
    private Rigidbody _rigidbody;

    public event Action<Bullet> Disappeared;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_lifeTime);
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Fly();
    }

    public void Hide()
    {
        Disappeared?.Invoke(this);
        gameObject.SetActive(false);
    }

    public void Init(Vector3 direction, Vector3 startPosition)
    {
        gameObject.SetActive(true);
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        _direction = direction;
        StartCoroutine(BulletExitLifeTime());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage();
        }

        Hide();
    }

    private void Fly()
    {
        _rigidbody.velocity = _direction * _bulletSpeed;
    }

    private IEnumerator BulletExitLifeTime()
    {
        yield return _waitForSeconds;
        Hide();
    }
}