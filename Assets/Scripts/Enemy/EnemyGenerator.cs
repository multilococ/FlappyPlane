using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private Transform _bulletContainer;
    [SerializeField] private float _delay;
    [SerializeField] private float _upperBound;
    [SerializeField] private float _lowerBound;

    private WaitForSeconds _waitForSeconds;

    private Coroutine _coroutine;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_delay);
    }

    private IEnumerator Generate() 
    {
        while (true)
        {
            yield return _waitForSeconds;

            Spawn();
        }
    }

    private void Spawn() 
    {
        float randomYposition = Random.Range(_lowerBound, _upperBound);
        Vector3 spawnPosition = new Vector3(transform.position.x,randomYposition,transform.position.z);
     
        Enemy enemy = _enemyPool.GetPrefab();

        enemy.Init(_bulletContainer);
        enemy.transform.position = spawnPosition;
    }

    public void StartGenerating() 
    {
        _coroutine = StartCoroutine(Generate());    
    }

    public void StopGenerating() 
    {
        _enemyPool.Reset();
        StopCoroutine(_coroutine);
    }
}
