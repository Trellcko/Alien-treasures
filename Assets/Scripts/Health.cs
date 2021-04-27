using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] private float _maxHealth;

    public event Action<float> DamageTook;
    public float MaxHealt => _maxHealth;


    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if(_currentHealth <= 0)
        {
            _currentHealth = 0;
        }

        DamageTook?.Invoke(_currentHealth);
    }

}
