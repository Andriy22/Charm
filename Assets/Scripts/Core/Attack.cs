using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public abstract class Attack<T> : MonoBehaviour where T : Health 
{
    [SerializeField] private int _damage;
    [SerializeField] private float _stun;
    [SerializeField] private float _kick;
    [SerializeField] private UnityEvent<T> _onAttack = new();
    [SerializeField] private UnityEvent _onAttackEnd = new();

    private float _attackSpeed = 1f;
    private bool _canAttack = true;

    public virtual bool CanAttack { get => _canAttack; }
    public virtual bool Stun { get => _stun > 0; }
    public virtual bool Kick { get => _kick > 0; }
    public virtual int Damage { get => _damage; }
    public event Action<T> OnAttack;
    public event Action OnAttackEnd;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (!CanAttack)
        {
            return;
        }

        if (other.gameObject.TryGetComponent(out T target))
        {
            PerformAttack(target);
        }
    }

    private void PerformAttack(T target)
    {
        target.TakeDamage(Damage);
        _canAttack = false;

        if ((Kick || Stun) && target.TryGetComponent(out IStunable stunable))
        {
            stunable.Stun(_stun);
        }

        if (Kick && target.TryGetComponent(out Rigidbody2D rigidbody2D))
        {
            rigidbody2D.AddForce((transform.position - rigidbody2D.transform.position).normalized * -_kick);
        }

        AllowAttack();
        OnAttack?.Invoke(target);
        _onAttack.Invoke(target);
    }

    private async Task AllowAttack()
    {
        await Task.Delay((int)(_attackSpeed * 1000));
        _canAttack = true;
        OnAttackEnd?.Invoke();
        _onAttackEnd?.Invoke();
    } 
}
