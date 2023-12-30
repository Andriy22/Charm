using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _scoreText;
    [SerializeField] private TMPro.TextMeshProUGUI _moneyText;

    public void OnScoreChange(int score)
    {
        _scoreText.text = score.ToString().PadLeft(8, '0');
    }

    public void OnMoneyChange(int money)
    {
        _moneyText.text = money.ToString();
    }

    private void OnEnable()
    {
        Score.OnMoneyChange += OnMoneyChange;
        Score.OnScoreChange += OnScoreChange;
    }

    private void OnDisable()
    {
        Score.OnMoneyChange -= OnMoneyChange;
        Score.OnScoreChange -= OnScoreChange;
    }
}
