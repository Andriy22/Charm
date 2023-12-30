using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _initialSpawnCount = 5;
    [SerializeField] private float _spawnDelay = 10;
    [SerializeField] private UnityEvent<int> _onWaveCleared = new();

    private int _currentSpawnedCount = 0;
    private int _amountOfEnemiesToSpawn = 0;

    private void Start()
    {
        _amountOfEnemiesToSpawn = _initialSpawnCount;

        SpawnEnemies(0, _amountOfEnemiesToSpawn);
    }

    private async Task SpawnEnemies(float delay, int count)
    {        
        await Task.Delay((int)(delay * 1000));

        for (int i = 0; i < count; i++)
        {
            var randomPosition = Random.Range(0, Mathf.PI * 2);

            var randomDirection = new Vector2(Mathf.Cos(randomPosition), Mathf.Sin(randomPosition));
            var enemy = Instantiate(_enemyPrefab, randomDirection * 10, Quaternion.identity);

            if (Random.Range(0,100) <= 10)
            {
                // spawn with charm
            }

            enemy.Health.OnDead += () => 
            {
                OnEmenyDeath();
                Score.OnEnemyDeath(enemy);
            };

            _currentSpawnedCount++;
        }

    }

    private void OnEmenyDeath()
    {
        _currentSpawnedCount--;

        if (_currentSpawnedCount == 0)
        {
            _onWaveCleared.Invoke(_amountOfEnemiesToSpawn);
            _amountOfEnemiesToSpawn += Random.Range(1, 3);

            SpawnEnemies(_spawnDelay, _amountOfEnemiesToSpawn);
        }
    }
}
