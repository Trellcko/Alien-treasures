using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttacking : MonoBehaviour
{
    [SerializeField] private float _damage;

    private LayerMask _enemyLayer;

    public void SetEnemyLayer(LayerMask layer)
    {
        _enemyLayer = layer;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (_enemyLayer == (_enemyLayer | (1 << collision.gameObject.layer)))
        {
            if (collision.gameObject.TryGetComponent(out Health health))
            {
                health.TakeDamage(_damage);
            }
        }
    }
}
