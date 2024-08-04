using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    public virtual Bullet Spawn(Vector2 position, Vector2 direction)
    {
        Bullet bullet = _pool.Get();
        bullet.Init(position, direction);

        return bullet;
    }

    public void ReleaseAll()
    {
        _pool.ReleaseAll();
    }
}