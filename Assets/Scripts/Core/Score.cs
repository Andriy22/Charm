using System;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    private static Score _instance;

    [SerializeField] private UnityEvent<int> _onMoneyChange = new();
    [SerializeField] private UnityEvent<int> _onScoreChange = new();

    public static event Action<int> OnMoneyChange;
    public static event Action<int> OnScoreChange;

    private int _score;
    private int _money;

    private void Awake() 
    {
        _instance = this;     
    }

    public static void OnEnemyDeath(Enemy enemy)
    {
        var amount = Mathf.RoundToInt((float)enemy.Health.MaxHealth * 0.1f);

        _instance._score += amount;
        _instance._onScoreChange.Invoke(_instance._score);
        OnScoreChange?.Invoke(_instance._score);

        _instance._money += amount;
        _instance._onMoneyChange.Invoke(_instance._money);
        OnMoneyChange?.Invoke(_instance._money);
    }

    public static bool TryTakeMoney(int amount)
    {
        if(_instance._money >= amount)
        {
            _instance._money -= amount;
            _instance._onMoneyChange.Invoke(_instance._money);
            OnMoneyChange?.Invoke(_instance._money);
            return true;
        }
        return false;
    }
}
