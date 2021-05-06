using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] private float _maxHealth;
    [SerializeField] private bool _canDestroy;
    [SerializeField] private AudioClip _takedDamageSound;
    [SerializeField] private AudioClip _deadSound;

    public event Action<float> DamageTaken;
    public event Action<float> HPRegenerated;
    public event Action Died;

    public float MaxHealt => _maxHealth;

    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void RegenerateHP(float bonusHp)
    {
        if (bonusHp <= 0) return;

        _currentHealth += bonusHp;
        if(_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        HPRegenerated?.Invoke(_currentHealth);
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0) return;

        _currentHealth -= damage;
        if(_currentHealth <= 0)
        {
            _currentHealth = 0;
            Died?.Invoke();
            AudioManager.Instance.PlaySound(_deadSound);
            if (_canDestroy)
            {
                Destroy(gameObject);
                return;
            }
        }
        AudioManager.Instance.PlaySound(_takedDamageSound);
        DamageTaken?.Invoke(_currentHealth);
    }

}
