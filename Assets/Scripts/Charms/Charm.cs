using UnityEngine;

public abstract class Charm : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;

    public abstract void OnWear(Animal animal);
    public abstract void OnDrop(Animal animal);
}