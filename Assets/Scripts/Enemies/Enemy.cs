using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IStunable
{
    [SerializeField] private string _name = "Immortal Object";
    [SerializeField] private Stats _stats;
    [SerializeField] private EnemyMovement _movement;
    [SerializeField] private EnemyHealth _health;
    [SerializeField] private EnemyAttack _attack;

    private Charm _currentCharm = null;
    private bool _stunned;
    private Coroutine _stunnedCoroutine;

    public Stats Stats => _currentCharm == null 
        ? _stats 
        : _stats + _currentCharm.Stats;

    public bool Stunned => _stunned;

    public event Action<Charm> OnCharmDrop;

    public EnemyMovement Movement { get => _movement; }
    public EnemyHealth Health { get => _health; }
    public EnemyAttack Attack { get => _attack; }

    public void Stun(float time)
    {
        if(_stunned)
        {
            StopCoroutine(_stunnedCoroutine);
        }

        _stunned =  true;
        _stunnedCoroutine = StartCoroutine(WaitStun(time));
    }

    private IEnumerator WaitStun(float amount)
    {
        yield return new WaitForSeconds(amount);
        _stunned = false;
    }

    private void Awake()
    {
        _movement.SetUp(this);
        _health.SetUp(this);
        _attack.SetUp(this);
    }
}
