using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _baseHealth = 100;
    [SerializeField] private int _currentHealth = 100;

    [SerializeField] private UnityEvent<int> _damageTaken = new();
    [SerializeField] private UnityEvent<int> _healed = new();
    [SerializeField] private UnityEvent<int, int> _healthChanged = new();

    [SerializeField]  private bool _isInvulnerable = false;

    public virtual int MaxHealth { get => _baseHealth; }
    public int CurrentHealth => _currentHealth;

    public event Action OnDead;

    private void Start() 
    {
        _currentHealth = MaxHealth;    
        _healthChanged.Invoke(_currentHealth, MaxHealth);
    }

    public virtual void TakeDamage(int damage)
    {
        if (_isInvulnerable)
        {
            return;
        }

        _currentHealth -= damage;

        _damageTaken.Invoke(damage);
        _healthChanged.Invoke(_currentHealth, MaxHealth);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Heal(int amount)
    {
        _currentHealth += amount;

        _healed.Invoke(amount);

        if (_currentHealth > MaxHealth)
        {
            _currentHealth = MaxHealth;
        }
        
        _healthChanged.Invoke(_currentHealth, MaxHealth);
    }

    private void Die()
    {
        OnDead?.Invoke();
        Destroy(gameObject);
    }
}
