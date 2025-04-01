using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private int _bulletCount;
    [SerializeField] private int _reloadDelay;

    private Queue<Bullet> _magazine = new Queue<Bullet>();  

    private void Start()
    {
        FillMagazine();
    }

    private void FillMagazine()
    {
        for (int i = 0; i < _bulletCount; i++)
        {
            Bullet bullet = Instantiate(_prefab);
            bullet.transform.parent = _container;
            _prefab.gameObject.SetActive(false);
            _magazine.Enqueue(bullet);
        }
    }

    private void ReturnBullet(Bullet bullet)
    {
        bullet.Disappeared -= ReturnBullet;
        _magazine.Enqueue(bullet);
    }

    public void Shoot()
    {
        if (_magazine.Count > 0)
        {
            Bullet bullet = _magazine.Dequeue();
            bullet.Init(transform.forward, transform.position);
            bullet.Disappeared += ReturnBullet;
        }
    }

    public void SetContainer(Transform container) 
    {
        _container = container;
    }
}
