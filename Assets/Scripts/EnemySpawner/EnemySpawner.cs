using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _route;
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private float _timeBetweenWaves;

    private Wave _currentWave;
    private int _currentWaveIndex;
    private int _enemysSpawned = 0;
    private float _timeBetweenSpawn = 0;

    private void Start()
    {
        _currentWaveIndex = 0;
        _currentWave = _waves[_currentWaveIndex];
    }

    private void Update()
    {
        if (_currentWave == null)
        {
            return;
        }

        _timeBetweenSpawn += Time.deltaTime;
        if (_timeBetweenSpawn >= _currentWave.Delay)
        {
            Spawn();
            CheckWaveEnd();
            _timeBetweenSpawn = 0;
        }
    }

    public void CheckWaveEnd()
    {
        if (_enemysSpawned == _currentWave.EnemyNumber)
        {
            _currentWave = null;
        }
    }

    public void Spawn()
    {
        var newEnemy = Instantiate(_currentWave.EnemyTemplate, _route[0].transform.position, Quaternion.identity);
        newEnemy.MoveState.SetRoute(_route);
        newEnemy.name = $"Enemy №{_enemysSpawned}";
        _enemysSpawned++;
    }

    [System.Serializable]
    public class Wave
    {
        public Enemy EnemyTemplate;
        public int EnemyNumber;
        public float Delay;
    }
}
