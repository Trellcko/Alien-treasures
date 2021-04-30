using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBottle : Loot
{
    private Health _playerHealth;

    private const float BONUS_HP = 25f;

    private void Awake()
    {
        _playerHealth = FindObjectOfType<PlayerMovement>().GetComponent<Health>();
    }

    public override void Effect()
    {
        _playerHealth.RegenerateHP(BONUS_HP);
    }
}
