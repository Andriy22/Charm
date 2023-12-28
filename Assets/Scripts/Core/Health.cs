using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _baseHealth = 100;
    [SerializeField] private int _currentHealth = 100;

    [SerializeField] private UnityEvent<int> _damageTaken = new();
    [SerializeField] private UnityEvent<int> _healed = new();
    [SerializeField] private UnityEvent<int> _healthChanged = new();
    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        _damageTaken.Invoke(damage);
        _healthChanged.Invoke(_currentHealth);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Heal(int amount)
    {
        _currentHealth += amount;

        _healed.Invoke(amount);
        _healthChanged.Invoke(_currentHealth);

        if (_currentHealth > _baseHealth)
        {
            _currentHealth = _baseHealth;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
