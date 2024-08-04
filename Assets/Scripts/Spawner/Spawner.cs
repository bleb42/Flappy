using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : SpawnableObject
{
    [SerializeField] protected Pool<T> _pool;

    public virtual SpawnableObject Spawn(Vector2 position)
    {
        SpawnableObject Object = _pool.Get();
        Object.Init(position);
        
        return Object;
    }
}