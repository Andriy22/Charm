using UnityEngine;

[CreateAssetMenu(fileName = "HealthCharm", menuName = "Scriptables/Charms/HealthCharm", order = 1)]
public class HealthCharm : Charm
{
    [SerializeField] private int _health;

    public override Stats Stats => new Stats(_health, 0, 0);

    public override void OnDrop(Animal animal)
    {
    }

    public override void OnWear(Animal animal)
    {
    }
}