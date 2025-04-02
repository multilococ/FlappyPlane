using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform _container;

    private Queue<Enemy> _pool;

    private void Awake()
    {
        _pool = new Queue<Enemy>();
    }
  
    public void ReturnObjectToPool(Enemy enemy)
    {
        enemy.Died -= ReturnObjectToPool;
        _pool.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }

    public void Reset()
    {
        int _childrenCount = _container.childCount;

        if (_childrenCount > 0)
        {
            for (int i = 0; i < _childrenCount; i++)
                _container.GetChild(i).GetComponent<Enemy>().Die();
        }
    }

    public Enemy GetPrefab()
    {
        Enemy enemy;

        if (_pool.Count == 0)
            enemy = Instantiate(_prefab);
        else
            enemy = _pool.Dequeue();

        enemy.gameObject.SetActive(true);
        enemy.Died += ReturnObjectToPool;
        enemy.transform.parent = _container;

        return enemy;
    }
}
