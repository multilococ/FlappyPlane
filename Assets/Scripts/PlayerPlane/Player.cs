using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour,IDamageable
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Button _shootButton;

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    public event Action GameIsOver;

    private void Start()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }

    private void OnEnable() 
    {
        _shootButton.onClick.AddListener(_weapon.Shoot);
        _collisionDetector.CollisionDetected += ProcessCollision;
        _inputReader.JumpPressed += _mover.FlyUp;
    }
 
    private void OnDisable()
    {
        _shootButton.onClick.RemoveListener(_weapon.Shoot);
        _collisionDetector.CollisionDetected -= ProcessCollision;
        _inputReader.JumpPressed -= _mover.FlyUp;
    }

    private void FixedUpdate()
    {
        _mover.Fall();
    }

    private void ProcessCollision(IInteractable interactable) 
    {
        if (interactable is OutOfBoundsZone || interactable is Enemy)
        {
            GameIsOver?.Invoke();
        }
    }

    public void Reset()
    {
        transform.position = _startPosition;
        _rigidbody.velocity = Vector3.zero;
        transform.rotation = _startRotation;
    }

    public void GetDamage()
    {
        GameIsOver?.Invoke();
    }
}