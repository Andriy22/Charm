using UnityEngine;

[CreateAssetMenu(fileName = "HealthCharm", menuName = "Scriptables/Charms/HealthCharm", order = 1)]
public class HealthCharm : Charm
{
    [SerializeField] private int _health;

    public override Stats Stats => new Stats(_health, 0, 0);

    protected override void OnDrop(Animal animal)
    {
    }

    protected override void OnWear(Animal animal)
    {
        animal.Health.Heal(_health);
    }
}