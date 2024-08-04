using System;

public class BirdBullet : Bullet    
{
    public event Action<BirdBullet> KilledEnemy;
    public event Action<BirdBullet> EnteredReleaseZone;

    protected override void OnCollisionDetected(IInteractable interactable)
    {
        if (interactable is Enemy)
            KilledEnemy?.Invoke(this);
        else if(interactable is ReleaseZone || interactable is EnemyBullet)
            EnteredReleaseZone?.Invoke(this);
    }
}