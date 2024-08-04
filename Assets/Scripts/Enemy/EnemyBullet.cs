using System;

public class EnemyBullet : Bullet
{
    public event Action<EnemyBullet> EnteredDieZone;

    protected override void OnCollisionDetected(IInteractable interactable)
    {
        if (interactable is Bird || interactable is ReleaseZone || interactable is BirdBullet)
        {
            EnteredDieZone?.Invoke(this);
        }
    }
}