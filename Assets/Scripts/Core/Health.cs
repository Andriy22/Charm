using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _baseHealth = 100;
    [SerializeField] private int _currentHealth = 100;

    [SerializeField] private UnityEvent<int> _damageTaken = new();
    [SerializeField] private UnityEvent<int> _healed = new();
    [SerializeField] private UnityEvent<int, int> _healthChanged = new();

    public virtual int MaxHealth { get => _baseHealth; }
    public int CurrentHealth => _currentHealth;

    private void Start() 
    {
        _currentHealth = MaxHealth;    
        _healthChanged.Invoke(_currentHealth, MaxHealth);
    }

    public virtual void TakeDamage(int damage)
    {
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
        Destroy(gameObject);
    }
}
