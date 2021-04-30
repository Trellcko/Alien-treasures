using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigibody;

    private Vector2 _direct;

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void SetParameters(Quaternion rotation, Vector2 driect)
    {
        transform.rotation = rotation;
        _direct = transform.up;
    }

    private void Move()
    {
        _rigibody.velocity = _speed * _direct;
    }

}
