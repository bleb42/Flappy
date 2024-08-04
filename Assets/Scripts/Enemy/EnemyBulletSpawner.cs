using UnityEngine;

public class EnemyBulletSpawner : BulletSpawner
{
    public override Bullet Spawn(Vector2 position, Vector2 direction)
    {
        EnemyBullet bullet = _pool.Get() as EnemyBullet;

        bullet.Init(position, direction);
        bullet.EnteredDieZone += OnEnteredReleaseZone;

        return bullet;
    }

    private void OnEnteredReleaseZone(EnemyBullet bullet)
    {
        _pool.Release(bullet);
        bullet.EnteredDieZone -= OnEnteredReleaseZone;
    }
}