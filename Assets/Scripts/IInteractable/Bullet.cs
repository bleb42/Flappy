using UnityEngine;

[RequireComponent(typeof(CollisionHandler), typeof(Rigidbody2D))]
public abstract class Bullet : SpawnableObject, IInteractable
{
    [SerializeField] private float _speed;

    private void Awake()
    {
        _handler = GetComponent<CollisionHandler>();
    }

    public void Init(Vector2 position, Vector2 direction)
    {
        gameObject.SetActive(true);
        transform.position = position;
        GetComponent<Rigidbody2D>().velocity = direction * _speed;
    }
} 