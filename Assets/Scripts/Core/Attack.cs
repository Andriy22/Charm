using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Attack<T> : MonoBehaviour where T : Health 
{
    private T _target;

    private int _damage;
    public virtual int Damage { get => _damage; }

    private float _attackSpeed = 0.5f;

    private bool canAttack = true;

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
            _target.TakeDamage(Damage);
            canAttack = false;

            AllowAttack();
            OnAttack?.Invoke(_target);
        }
    }

    private async Task AllowAttack()
    {
        await Task.Delay((int)(_attackSpeed * 1000));
        canAttack = true;
        OnAttackEnd?.Invoke();
    } 
}
