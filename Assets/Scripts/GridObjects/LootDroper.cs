using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDroper : MonoBehaviour
{
    [SerializeField] private Loot _loot;
    [SerializeField] private Health _health;
    [SerializeField] private Transform _spawnPoint;

    private void Start()
    {
        _health.Died += Drop;
    }

    private void Drop()
    {
        if (_loot == null)
        {
            return;
        }
        Instantiate(_loot, _spawnPoint.position, Quaternion.identity);
    }

}
