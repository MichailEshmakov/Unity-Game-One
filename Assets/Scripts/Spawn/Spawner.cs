using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GlobalSpeed _globalSpeed;
    [SerializeField] private SpawnPool _cupSpawnPool;
    [SerializeField] private SpawnPool _coinSpawnPool;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _gapTime;
    [SerializeField] private float _cupProbability;

    private float _elapsedTime = 0;
    private float _currentDelay;
    private List<SpawnableObject> _nextObjects;
    private bool _isCupSpawnTurn;

    private void Start()
    {
        TrySetNextObjects();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime * _globalSpeed.Value;

        if (_elapsedTime >= _currentDelay)
        {
            if (_nextObjects != null && _nextObjects.Count > 0)
            {
                TrySpawnNextObject();
            }
            else
            {
                TrySetNextObjects();
            }
        }
    }

    private void TrySpawnNextObject()
    {
        _elapsedTime = 0;
        SpawnableObject nextObject = _nextObjects[_nextObjects.Count - 1];
        _nextObjects.RemoveAt(_nextObjects.Count - 1);
        Spawn(nextObject);
        _currentDelay = nextObject.RightOffset;
        if (_nextObjects.Count == 0)
        {
            TrySetNextObjects();
        }
        else
        {
            _currentDelay += _nextObjects[_nextObjects.Count - 1].LeftOffset;
        }
    }

    private void Spawn(SpawnableObject spawnableObject)
    {
        spawnableObject.gameObject.SetActive(true);
        spawnableObject.transform.position = _spawnPoint.position;
    }

    private void TrySetNextObjects()
    {
        SpawnPool spawnPool = _isCupSpawnTurn ? _cupSpawnPool : _coinSpawnPool;
        List<SpawnableObject> nextObjects = spawnPool.GetObjects();

        if (nextObjects.Count > 0)
        {
            _currentDelay += _gapTime;
            _nextObjects = nextObjects;
            _isCupSpawnTurn = UnityEngine.Random.Range(0f, 1f) < _cupProbability;
            _currentDelay += _nextObjects[_nextObjects.Count -1].LeftOffset;
        }
    }
}
