public class AnimalHealth : Health, IAnimalPart
{
    private Animal _animal;

    public override int MaxHealth => Animal.Stats.Health;

    public Animal Animal => _animal;

    public void SetUp(Animal animal)
    {
        _animal = animal;
    }
}
