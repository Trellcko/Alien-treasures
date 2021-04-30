using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon
{
    [SerializeField] private BulletMovement _bullet;
    [SerializeField] private Transform _spawnPosition;

    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        _animator.AttackFinishing += () => {
            _isAttacking = false;
            InstantiateBullet();
        };
    }


    public override void Attack()
    {
        _isAttacking = true;
        _animator.RunAttackAnimation();
    }

    private void InstantiateBullet()
    {
        var bullet = Instantiate(_bullet, _spawnPosition.position, Quaternion.identity);
        bullet.SetParameters(_transform.rotation, _transform.right);
        if (bullet.gameObject.TryGetComponent(out BulletAttacking attacking))
        {
            attacking.SetEnemyLayer(_enemyLayer);
        }
    }

}
