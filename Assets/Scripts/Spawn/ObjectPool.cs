using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();
    private bool _inited;

    protected GameObject Prefab => _prefab;
    protected bool Inited => _inited;


    protected virtual void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < _capacity; i++)
        {
            SpawnToPool(_prefab);
        }

        _inited = true;
    }

    private void SpawnToPool(GameObject prefab)
    {
        GameObject spawned = Instantiate(prefab, _container);
        spawned.SetActive(false);

        _pool.Add(spawned);
    }

    protected List<GameObject> GetObjects(int amount)
    {
        return _pool.Where(p => p.activeSelf == false).Take(amount).ToList();
    }

    protected List<T> GetComponentsInPool<T>()
    {
        List<T> components = new List<T>();
        foreach (GameObject poolObject in _pool)
        {
            if (poolObject.TryGetComponent(out T component))
            {
                components.Add(component);
            }
        }

        return components;
    }
}
