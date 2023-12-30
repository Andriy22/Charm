using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimalInfoManager : MonoBehaviour
{
    public static AnimalInfoManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void DisplayTooltip(Animal animal)
    {
        _text.text = $"{animal.name}\nMax HP: {animal.Stats.Health}\nDamage: {animal.Stats.Damage}\nSpeed: {animal.Stats.Speed}";
        gameObject.SetActive(true);
        //transform.position = Input.mousePosition;
    }

    public void HideTooltip()
    {
        _text.text = "";
        gameObject.SetActive(false);
    }
}
