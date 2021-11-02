using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPool : ObjectPool
{
    [SerializeField] private SpeedKeeper _speedKeeper;
    [SerializeField] private int _minQueueLength;
    [SerializeField] private int _maxQueueLength;

    private void OnValidate()
    {
        if (Prefab.TryGetComponent(out SpawnableObject spawnableObject) == false)
        {
            Debug.LogError($"{Prefab.name} should be SpawnableObject");
        }
    }

    protected override void Start()
    {
        base.Start();
        InitMovers();
    }

    private void InitMovers()
    {
        List<Mover> movers = GetComponentsInPool<Mover>();
        if (movers != null)
        {
            foreach (Mover mover in movers)
            {
                mover.Init(_speedKeeper.Speed);
            }
        }
    }

    public List<SpawnableObject> GetObjects()
    {
        int objectsAmount = UnityEngine.Random.Range(_minQueueLength, _maxQueueLength + 1);
        List<SpawnableObject> nextObjects = new List<SpawnableObject>(objectsAmount);
        List<GameObject> nextGameObjects = GetObjects(objectsAmount);

        foreach (GameObject newGameObject in nextGameObjects)
        {
            if (newGameObject.TryGetComponent(out SpawnableObject spawnableObject))
            {
                nextObjects.Add(spawnableObject);
            }
        }
        
        return nextObjects;
    }
}
