using UnityEngine;

public abstract class Charm : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;

    public abstract Stats Stats { get; }

    public void Wear(Animal animal)
    {
        animal.CurrentCharm = this;
        OnWear(animal);
    }

    public void Drop(Animal animal)
    {
        animal.CurrentCharm = null;
        OnDrop(animal);
    }

    protected abstract void OnWear(Animal animal);
    protected abstract void OnDrop(Animal animal);
}