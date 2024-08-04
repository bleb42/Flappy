using System.Collections;
using UnityEngine;

public class BirdShooter : MonoBehaviour
{
    [SerializeField] private float _shootDelay = 1.5f;
    [SerializeField] private BirdBulletSpawner _bulletSpawner;

    private bool _canShoot = true; 

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canShoot)
        {
            _bulletSpawner.Spawn(transform.position, Vector2.right);
            StartCoroutine(HandleShootDelay());
        }
    }

    private IEnumerator HandleShootDelay()
    {
        _canShoot = false;

        yield return new WaitForSeconds(_shootDelay);

        _canShoot = true;
    }

    public void Reset()
    {
        _canShoot = true; 
    }
}
