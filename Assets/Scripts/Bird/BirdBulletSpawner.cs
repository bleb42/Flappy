using UnityEngine;

public class BirdBulletSpawner : BulletSpawner
{
    [SerializeField] private ScoreCounter _score;

    public override Bullet Spawn(Vector2 position, Vector2 direction)
    {
        BirdBullet bullet = _pool.Get() as BirdBullet;

        bullet.KilledEnemy += OnKilledEnemy;
        bullet.EnteredReleaseZone += OnEnteredReleaseZone;
        bullet.Init(position, direction);
        
        return bullet;
    }

    private void OnKilledEnemy(BirdBullet bullet)
    {
        _score.Add();
        bullet.KilledEnemy -= OnKilledEnemy;
        bullet.EnteredReleaseZone -= OnEnteredReleaseZone;
        _pool.Release(bullet);
    }

    private void OnEnteredReleaseZone(Bullet bullet)
    {
        if (bullet is BirdBullet birdBullet)
        {
            birdBullet.KilledEnemy -= OnKilledEnemy;
            birdBullet.EnteredReleaseZone -= OnEnteredReleaseZone;
        }

        _pool.Release(bullet);
    }
}