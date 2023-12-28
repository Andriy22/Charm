using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private string _name = "Immortal Object";
    [SerializeField] private AnimalMovement _movement;
    [SerializeField] private AnimalHealth _health;

    [SerializeField] private CowardiceState _cowardiceState = CowardiceState.Neutral;
    private Charm _currentCharm = null;

    public CowardiceState CowardiceState { get => _cowardiceState; set => _cowardiceState = value; }

    public event Action<Charm> OnCharmWear;
    public event Action<Charm> OnCharmDrop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
