using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string _name = "Immortal Object";
    [SerializeField] private Stats _stats;
    [SerializeField] private EnemyMovement _movement;
    [SerializeField] private EnemyHealth _health;
    [SerializeField] private EnemyAttack _attack;

    private Charm _currentCharm = null;

    public Stats Stats => _currentCharm == null 
        ? _stats 
        : _stats + _currentCharm.Stats;
        
    public event Action<Charm> OnCharmDrop;

    private void Awake()
    {
        _movement.SetUp(this);
        _health.SetUp(this);
        _attack.SetUp(this);
    }
}
