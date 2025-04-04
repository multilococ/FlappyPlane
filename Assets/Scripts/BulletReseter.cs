using UnityEngine;

public class BulletReseter : MonoBehaviour
{
    [SerializeField] private Transform _container;

    public void Reset()
    {
        for (int i = 0; i < _container.childCount; i++)
        {
            if (_container.GetChild(i).TryGetComponent(out Bullet bullet)) 
            {
                bullet.Hide();
            }
        }
    }
}
