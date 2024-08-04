using System;
using UnityEngine;

[RequireComponent(typeof(ScoreCounter), typeof(CollisionHandler), typeof(BirdMover))]
[RequireComponent(typeof(BirdShooter))]
public class Bird : MonoBehaviour, IInteractable
{
    private BirdMover _birdMover;
    private ScoreCounter _scoreCounter;
    private CollisionHandler _handler;
    private BirdShooter _birdShooter;

    public event Action Died;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _handler = GetComponent<CollisionHandler>();
        _birdMover = GetComponent<BirdMover>();
        _birdShooter = GetComponent<BirdShooter>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }


    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Enemy || interactable is EnemyBullet || interactable is Floor)
            Died?.Invoke();
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _birdMover.Reset();
        _birdShooter.Reset();
    }
}