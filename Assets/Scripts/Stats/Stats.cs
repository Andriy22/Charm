using System;
using UnityEngine;

[Serializable]
public struct Stats
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    public Stats(int health, float speed, int damage)
    {
        _health = health;
        _speed = speed;
        _damage = damage;
    }

    public int Health => _health;
    public float Speed => _speed;
    public int Damage => _damage;

    public static Stats operator +(Stats a)
    {
        return a;
    }

    public static Stats operator -(Stats a)
    {
        return new Stats(-a.Health, -a.Speed, -a.Damage);
    }

    public static Stats operator +(Stats a, Stats b)
    {
        return new Stats(a.Health + b.Health, a.Speed + b._speed, a.Damage + b.Damage);
    }

    public static Stats operator -(Stats a, Stats b)
    {
        return a + (-b);
    }

    public static Stats operator *(Stats a, float b)
    {
        return new Stats(Mathf.RoundToInt(a.Health * b), Mathf.RoundToInt(a.Speed * b), Mathf.RoundToInt(a.Damage * b));
    }

    public static Stats operator /(Stats a, float b)
    {
        return new Stats(Mathf.RoundToInt(a.Health / b), Mathf.RoundToInt(a.Speed / b), Mathf.RoundToInt(a.Damage / b));
    }
}