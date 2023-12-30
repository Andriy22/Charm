public class EnemyAttack : Attack<AnimalHealth>, IEnemyPart
{
    public Enemy Enemy { get; private set; }

    public override int Damage => Enemy.Stats.Damage;

    public void SetUp(Enemy enemy)
    {
        Enemy = enemy;
    }
}

