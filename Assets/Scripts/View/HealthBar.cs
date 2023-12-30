using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void UpdateBar(int amount, int maxAmount)
    {
        _image.DOKill();
        _image.DOFillAmount((float)amount/(float)maxAmount, 0.2f);
    }
}
