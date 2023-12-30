using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public abstract class Attack<T> : MonoBehaviour where T : Health 
{
    private T _target;

    [SerializeField] private int _damage;
    [SerializeField] private float _stun;
    [SerializeField] private float _kick;
    [SerializeField] private UnityEvent<T> _onAttack = new();
    [SerializeField] private UnityEvent _onAttackEnd = new();

    private float _attackSpeed = 0.5f;
    private bool canAttack = true;

    public virtual bool Stun { get => _stun > 0; }
    public virtual bool Kick { get => _kick > 0; }
    public virtual int Damage { get => _damage; }
    public event Action<T> OnAttack;
    public event Action OnAttackEnd;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!canAttack)
        {
            return;
        }

        if (collision.gameObject.TryGetComponent(out _target))
        {
            PerformAttack(collision);
        }
    }

    private void PerformAttack(Collision2D collision)
    {
        _target.TakeDamage(Damage);
        canAttack = false;

        if ((Kick || Stun) && collision.gameObject.TryGetComponent(out IStunable stunable))
        {
            stunable.Stun(_stun);
        }

        if (Kick && collision.gameObject.TryGetComponent(out Rigidbody2D rigidbody2D))
        {
            rigidbody2D.AddForce((transform.position - rigidbody2D.transform.position).normalized * _kick);
        }

        AllowAttack();
        OnAttack?.Invoke(_target);
        _onAttack.Invoke(_target);
    }

    private async Task AllowAttack()
    {
        await Task.Delay((int)(_attackSpeed * 1000));
        canAttack = true;
        OnAttackEnd?.Invoke();
        _onAttackEnd?.Invoke();
    } 
}
