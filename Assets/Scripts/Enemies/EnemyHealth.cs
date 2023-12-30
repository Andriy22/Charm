public class EnemyHealth : Health, IEnemyPart
{
    public Enemy Enemy { get; private set; }

    public override int MaxHealth => Enemy.Stats.Health;

    public void SetUp(Enemy enemy)
    {
        Enemy = enemy;
    }
}