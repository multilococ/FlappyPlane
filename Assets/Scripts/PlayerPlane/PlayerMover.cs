using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _verticalForce;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Vector3 _startPosition;

    private Rigidbody _rigidbody;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _startPosition = transform.position;
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    public void FlyUp() 
    {
        _rigidbody.velocity = new Vector3(_horizontalSpeed,_verticalForce);
        transform.rotation = _maxRotation;
    }

    public void Fall() 
    {
        transform.rotation = Quaternion.Lerp(transform.rotation,_minRotation,_rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector3.zero;
    }
}
