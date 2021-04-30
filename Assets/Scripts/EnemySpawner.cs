using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Health _enemyPrefab;

    [SerializeField] private Health _myHealth;

    [SerializeField] private int _maxEnemyCount;
    [SerializeField] private int _spawnTime;

    private int _currentEnemyCount = 0;

    private bool _isSpawning = false;

    private List<Health> _myEnemy = new List<Health>();

    private void Start()
    {
        _myHealth.Died += UnSubcribe;
    }

    private void Update()
    {
        if(_currentEnemyCount < _maxEnemyCount && _isSpawning == false)
        {
            StartCoroutine(SpawnCorun());
        }
    }

    private void DecreaseEnemyCount()
    {
        _currentEnemyCount --;
    }

    private void UnSubcribe()
    {
        foreach (var enemy in _myEnemy)
        {
            if (enemy != null)
            {
                enemy.Died -= DecreaseEnemyCount;
            }
        }
    }

    private IEnumerator SpawnCorun()
    {
        _isSpawning = true;
        yield return new WaitForSeconds(_spawnTime);
        
        var enemy = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);
        _myEnemy.Add(enemy);
        enemy.Died += DecreaseEnemyCount;
        
        _currentEnemyCount++;
        _isSpawning = false;
    }

}
