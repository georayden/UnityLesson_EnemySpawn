using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectPool
{

    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnFrequency = 2;

    [SerializeField] private SpawnPoint[] _spawnPoints;

    private int currentSpawnPoint = 0;
    private float _elapsedTime = 0;    

    private void Start()
    {
        _spawnPoints = gameObject.GetComponentsInChildren<SpawnPoint>();
        Initialize(_enemyPrefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _spawnFrequency)
        {
            if(TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;

                enemy.GetComponent<Enemy>().SetTarget(_player);

                SetEnemy(enemy, _spawnPoints[currentSpawnPoint].transform.position);

                currentSpawnPoint++;

                if (currentSpawnPoint == _spawnPoints.Length)
                {
                    currentSpawnPoint = 0;
                }
            }            
        }
    }

    private void SetEnemy(GameObject enemy,  Vector3 spawnPoint)
    {
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
