using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;

    private Vector3 _position;
    private Rigidbody2D _rigidbody2D;
    private Vector3 center;

    private void Awake()
    {
        _position = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        center = Vector3.zero;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (center - transform.position).normalized;
        Vector3 velocity = direction * _speed;

        _rigidbody2D.velocity = velocity;
    }
}