using System;
using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
public abstract class SpawnableObject : MonoBehaviour, IInteractable
{
    protected CollisionHandler _handler;

    private void Awake()
    {
        _handler = GetComponent<CollisionHandler>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += OnCollisionDetected;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= OnCollisionDetected;
    }

    public virtual void Init(Vector2 position)
    {
        gameObject.SetActive(true);
        transform.position = position;
    }

    protected abstract void OnCollisionDetected(IInteractable interactable);
} 