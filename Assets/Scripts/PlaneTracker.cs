using UnityEngine;

public class PlaneTracker : MonoBehaviour
{
    [SerializeField] private Player _target;

    [SerializeField] private float _xOffset;

    private void Update()
    {
        SetNewPosition();
    }

    private void SetNewPosition()
    {
        Vector3 nextPostion = transform.position;

        nextPostion.x = _xOffset + _target.transform.position.x;
        transform.position = nextPostion;
    }
}
