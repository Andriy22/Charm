using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAttack : Attack<EnemyHealth>, IAnimalPart
{
    private Animal _animal;
    public Animal Animal => _animal;

    public override int Damage => Animal.Stats.Damage;
    public override bool CanAttack => base.CanAttack && !Animal.Stunned;

    public void SetUp(Animal animal)
    {
        _animal = animal;
    }
}
