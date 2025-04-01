using UnityEngine;

public class EnemyRemover : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent(out Enemy enemy))
            enemy.Die();
    }
}
