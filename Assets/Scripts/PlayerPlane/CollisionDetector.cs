using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action<IInteractable> CollisionDetected;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IInteractable interactable)) 
        {
            CollisionDetected?.Invoke(interactable);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out IInteractable interactable))
        {
            CollisionDetected?.Invoke(interactable);
        }
    }
}
