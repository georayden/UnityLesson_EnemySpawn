using System.Collections;
using UnityEngine;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private Transform _player;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _spawnFrequency = 2;

    private SpawnPoint[] _spawnPoints;

    private int _currentSpawnPoint = 0;
    private bool _isWork;

    private void Start()
    {
        _spawnPoints = gameObject.GetComponentsInChildren<SpawnPoint>();

        Initialize(_enemyPrefab.gameObject);

        StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        var waitForSeconds = new WaitForSeconds(_spawnFrequency);

        _isWork = true;

        while (_isWork)
        {
            if (TryGetObject(out GameObject enemy))
            {
                enemy.GetComponent<Enemy>().SetTarget(_player);

                SetEnemy(enemy, _spawnPoints[_currentSpawnPoint].transform.position);

                _currentSpawnPoint++;

                if (_currentSpawnPoint == _spawnPoints.Length)
                {
                    _currentSpawnPoint = 0;
                }
            }

            yield return waitForSeconds;
        }
    }

    public void Stop()
    {
        _isWork = false;
    }

    private void SetEnemy(GameObject enemy,  Vector3 spawnPoint)
    {
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
