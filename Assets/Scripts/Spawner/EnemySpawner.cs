using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private EnemyBulletSpawner _bulletSpawner;
    [SerializeField] private float _spawningDelay;
    [SerializeField] private Transform[] _spawnpoints;

    private Coroutine _spawningEnemies;
    private bool _isSpawning;

    public void StartSpawning()
    {
        _spawningEnemies = StartCoroutine(SpawningEnemys());
    }

    public void StopSpawning()
    {
        _isSpawning = false;

        if (_spawningEnemies != null)
        {
            StopCoroutine(_spawningEnemies);
        }
    }

    public void ReleaseAll()
    {
        _pool.ReleaseAll();
    }

    private IEnumerator SpawningEnemys()
    {
        _isSpawning = true;
        WaitForSeconds delay = new WaitForSeconds(_spawningDelay);

        while (_isSpawning)
        {
            yield return delay;
            
            Transform spawnpoint = _spawnpoints[Random.Range(0, _spawnpoints.Length)];

            Enemy enemy = Spawn(spawnpoint.position) as Enemy;
            enemy.Died += ReleaseEnemy;
            enemy.Shoot += Shoot;
        }
    }

    private void ReleaseEnemy(SpawnableObject enemy)
    {
        Enemy enemyToRelease = enemy as Enemy;
        enemyToRelease.Shoot -= Shoot;
        enemyToRelease.Died -= ReleaseEnemy;
        _pool.Release(enemy as Enemy);
    }

    private void Shoot(Vector2 startPosition, Vector2 direction)
    {
        EnemyBullet bullet = _bulletSpawner.Spawn(startPosition, direction) as EnemyBullet;
        bullet.Init(startPosition, direction);
    }
}