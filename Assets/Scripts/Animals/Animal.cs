using System;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private string _name = "Immortal Object";
    [SerializeField] private Stats _stats;
    [SerializeField] private AnimalMovement _movement;
    [SerializeField] private AnimalHealth _health;

    [SerializeField] private CowardiceState _cowardiceState = CowardiceState.Neutral;
    private Charm _currentCharm = null;

    public CowardiceState CowardiceState { get => _cowardiceState; set => _cowardiceState = value; }
    public Stats Stats => _stats + _currentCharm.Stats;
    public event Action<Charm> OnCharmWear;
    public event Action<Charm> OnCharmDrop;

    private void Awake() {
        _movement.SetUp(this);
        _health.SetUp(this);   
    }
}
