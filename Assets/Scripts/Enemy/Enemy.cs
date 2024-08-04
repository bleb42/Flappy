using System;
using System.Collections;
using UnityEngine;

public class Enemy : SpawnableObject, IInteractable
{
    [SerializeField] private float _shootingDelay = 2f;

    private Coroutine _shooting;
    private bool _isShooting = false;

    public event Action<Vector2, Vector2> Shoot;
    public event Action<Enemy> Died;

    public override void Init(Vector2 position)
    {
        base.Init(position);

        _shooting = StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        WaitForSeconds delay = new WaitForSeconds(_shootingDelay);
        _isShooting = true;

        while (_isShooting)
        {
            yield return delay;

            Shoot?.Invoke(transform.position, Vector2.left);
        }
    }

    protected override void OnCollisionDetected(IInteractable interactable)
    {
        if (interactable is ReleaseZone || interactable is BirdBullet)
            Died?.Invoke(this);
    }
}