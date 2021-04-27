using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Transform _fill;


    private float _maxHealth;

    

    private void Start()
    {
        _maxHealth = _health.MaxHealt;
        _health.DamageTook += ChangeValue;
    }

    public void ChangeValue(float health)
    {
        float value = health / _maxHealth;
        _fill.localScale = new Vector3(value, _fill.localScale.y, 1);
    }

}
