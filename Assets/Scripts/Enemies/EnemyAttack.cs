public class EnemyAttack : Attack<AnimalHealth>, IEnemyPart
{
    public Enemy Enemy { get; private set; }

    public override int Damage => Enemy.Stats.Damage;
    public override bool CanAttack => base.CanAttack && !Enemy.Stunned;

    public void SetUp(Enemy enemy)
    {
        Enemy = enemy;
    }
}

