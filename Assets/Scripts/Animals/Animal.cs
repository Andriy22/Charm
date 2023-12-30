using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class Animal : MonoBehaviour, IStunable
{
    [SerializeField] private string _name = "Immortal Object";
    [SerializeField] private Stats _stats;
    [SerializeField] private AnimalMovement _movement;
    [SerializeField] private AnimalHealth _health;
    [SerializeField] private AnimalAttack _attack;

    [SerializeField] private CowardiceState _cowardiceState = CowardiceState.Neutral;
    private Charm _currentCharm = null;
    private bool _stunned;
    private Coroutine _stunnedCoroutine;

    public CowardiceState CowardiceState { get => _cowardiceState; set => _cowardiceState = value; }
    public Stats Stats => CurrentCharm == null 
        ? _stats 
        : _stats + CurrentCharm.Stats;

    public Charm CurrentCharm
    {
        get => _currentCharm; 
        set
        {
            if(_currentCharm != null && value != null)
            {
                _currentCharm.Drop(this);
                value.Wear(this);
                return;
            }

            _currentCharm = value;
            
            if(value == null)
            {
                OnCharmDrop?.Invoke(_currentCharm);
            }

            if(value != null)
            {
                OnCharmWear?.Invoke(_currentCharm);
            }
        }
    }

    public AnimalMovement Movement { get => _movement; }
    public AnimalHealth Health { get => _health; }
    public AnimalAttack Attack { get => _attack; }

    public bool Stunned => _stunned;

    public event Action<Charm> OnCharmWear;
    public event Action<Charm> OnCharmDrop;

    public void Stun(float time)
    {
        if(_stunned)
        {
            StopCoroutine(_stunnedCoroutine);
        }

        _stunned = true;
        _stunnedCoroutine = StartCoroutine(WaitStun(time));
    }

    private IEnumerator WaitStun(float amount)
    {
        yield return new WaitForSeconds(amount);
        _stunned = false;
    }

    private void Awake() {
        _movement.SetUp(this);
        _health.SetUp(this);
        _attack.SetUp(this);
    }
}
