using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class Pool<T> : MonoBehaviour where T : SpawnableObject
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolCapacity = 10;
    [SerializeField] private int _poolMaxSize = 10;

    protected ObjectPool<T> _pool;
    protected List<T> _activeObjects = new List<T>();

    protected virtual void Awake()
    {
        _pool = new ObjectPool<T>(
                    createFunc: () => Instantiate(_prefab),
                    actionOnGet: (obj) => ActivateOnGet(obj),
                    actionOnRelease: (obj) => ActivateOnRelease(obj),
                    actionOnDestroy: (obj) => Destroy(obj),
                    collectionCheck: true,
                    defaultCapacity: _poolCapacity,
                    maxSize: _poolMaxSize);
    }

    public virtual T Get()
    {
        return _pool.Get();
    }

    public void Release(T obj)
    {
        if (_activeObjects.Contains(obj))
        {
            _pool.Release(obj);
        }
    }

    public void ReleaseAll()
    {
        foreach (var obj in _activeObjects.ToList())
            Release(obj);
    }

    protected virtual void ActivateOnGet(T obj)
    {
        obj.gameObject.SetActive(true);
        _activeObjects.Add(obj);
    }

    protected virtual void ActivateOnRelease(T obj)
    {
        obj.gameObject.SetActive(false);
        _activeObjects.Remove(obj);
    }
}