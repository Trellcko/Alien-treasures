using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathFinding;

public class EnemyAttacking : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private Transform _playerTransform;
    private Transform _transform;

    [SerializeField] private float _attackDistance = 1F;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _playerTransform = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        if(Vector2.Distance(_playerTransform.position, _transform.position) <= _attackDistance)
        {
            Attack();
        }
    }

    public void Attack()
    {
        _weapon.Attack();
    }
}
