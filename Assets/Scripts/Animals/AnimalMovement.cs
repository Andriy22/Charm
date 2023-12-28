using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _distance = 1f;

    private Vector2 _position;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _destination;

    private void Awake()
    {
        _position = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        SetRandomDestination();
    }
   
    private void FixedUpdate()
    {
        float distanceToDestination = Vector2.Distance(_position, _destination);

        if (distanceToDestination < 0.1f)
        {
            SetRandomDestination();
            return;
        }

        Vector2 direction = (_destination - _position).normalized;
        Vector2 velocity = direction * _speed;

        _rigidbody2D.velocity = velocity;
    }

    private void SetRandomDestination()
    {
        var randomOffset = Random.insideUnitCircle * _distance;
        _destination = _position + randomOffset;
    }
}
