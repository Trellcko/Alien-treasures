using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private MeleeWeaponAnimator _animator;
    [SerializeField] private float _damage;

    [SerializeField] private AudioClip _audio;

    private List<Collider2D> _attackedColliders = new List<Collider2D>();

    private bool _isAttacking = false;

    private void Start()
    {
        _animator.AttackStarted += () =>
        {
            _isAttacking = true;
            AudioManager.Instance.PlaySound(_audio);
        };

        _animator.AttackFinished += () => { 
            _isAttacking = false;
            _attackedColliders.Clear();
        };    
    }

    public override void Attack()
    {
        _animator.RunAttackAnimation();
    }
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isAttacking == false) return;
        if(_enemyLayer == (_enemyLayer | (1 << collision.gameObject.layer)) && _attackedColliders.Contains(collision) == false)
        {
            if(collision.gameObject.TryGetComponent(out Health health))
            {
                _attackedColliders.Add(collision);
                health.TakeDamage(_damage);
            }
        }
    }

}
