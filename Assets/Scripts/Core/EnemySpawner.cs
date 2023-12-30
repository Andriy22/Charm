using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _initialSpawnCount = 5;

    private int _currentSpawnCount = 0;
    private List<Enemy> _enemies = new List<Enemy>();

    void Start()
    {
        if (useTimeBasedSpawn)
        {
            StartCoroutine(SpawnEnemyWithInterval());
        }
    }

    private IEnumerator SpawnEnemyWithInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnInterval);
            SpawnEnemy();
        }
    }

    private void SpawnEnemies(int count)
    {
        for (int i = 0; i < _initialSpawnCount; i++)
        {
            var randomPosition = Random.Range(0, Mathf.PI * 2);

            var randomDirection = new Vector2(Mathf.Cos(randomPosition), Mathf.Sin(randomPosition));
            var enemy = Instantiate(_enemyPrefab, randomDirection * 10, Quaternion.identity);

            enemy.Health
        }

    }


}
