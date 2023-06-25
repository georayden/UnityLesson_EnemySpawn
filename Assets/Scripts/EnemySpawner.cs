using UnityEngine;

public class EnemySpawner : ObjectPool
{

    [SerializeField] private Transform _player;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _spawnFrequency = 2;

    [SerializeField] private SpawnPoint[] _spawnPoints;

    private int _currentSpawnPoint = 0;
    private float _elapsedTime = 0;    

    private void Start()
    {
        _spawnPoints = gameObject.GetComponentsInChildren<SpawnPoint>();

        Initialize(_enemyPrefab.gameObject);
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

                SetEnemy(enemy, _spawnPoints[_currentSpawnPoint].transform.position);

                _currentSpawnPoint++;

                if (_currentSpawnPoint == _spawnPoints.Length)
                {
                    _currentSpawnPoint = 0;
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
