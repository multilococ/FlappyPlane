using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour,IInteractable,IDamageable
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _shootDelay;

    public event Action<Enemy> Died;

    private void OnEnable()
    {
        StartCoroutine(DelayFromShoot());
    }

    private IEnumerator DelayFromShoot() 
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_shootDelay);
     
        while (true)
        {
            yield return waitForSeconds ;

            _weapon.Shoot();
        }
    }

    public void Init(Transform container) 
    {
        _weapon.SetContainer(container);
    }

    public void Die() 
    {
        Died?.Invoke(this);
    }

    public void GetDamage()
    {
        Die();
    }
}
