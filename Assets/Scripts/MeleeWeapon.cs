using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [SerializeField] private WeaponAnimator _animator;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _damage;

    private bool _isAttack = false;

    private void Start()
    {
        _animator.AttackFinishing += () => { _isAttack = false; };    
    }

    public void Attack()
    {
        _isAttack = true;
        _animator.RunAttackAnimation();
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isAttack == false) return;

        if(collision.gameObject.layer == _enemyLayer)
        {
            if(TryGetComponent(out Health health))
            {
                health.TakeDamage(_damage);
            }
        }
    }

}
