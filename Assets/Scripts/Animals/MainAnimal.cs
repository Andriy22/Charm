using UnityEngine;

public class MainAnimal : MonoBehaviour
{
    private static Animal _animal;

    public static Animal Animal { get => _animal; }

    private void Awake() {
        if(_animal == null)
        {
            _animal = GetComponent<Animal>();
        }
    }

    private void OnDestroy() {
        if(_animal == GetComponent<Animal>())
        {
            _animal = null;
        }
    }
}