using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action<IInteractable> CollisionDetected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            CollisionDetected?.Invoke(interactable);
        }
    }
}