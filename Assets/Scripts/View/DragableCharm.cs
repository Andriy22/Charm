using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableCharm : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Charm _charm;

    private bool _holding;
    private LayoutElement _layoutElemrnt;
    private Camera _camera;

    private Vector3 _velocity;

    private void Awake()
    {
        _layoutElemrnt = GetComponent<LayoutElement>();
        _camera = Camera.main;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _holding = true;
        _layoutElemrnt.ignoreLayout = true;
        Debug.Log("aasdasd");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _holding = false;

        var position = _camera.ScreenToWorldPoint(transform.position, Camera.MonoOrStereoscopicEye.Mono);
        var results = Physics2D.OverlapCircleAll(position, 1);
        Animal animal = null;

        Debug.Log(results.Length);
        for (int i = 0; i < results.Length; i++)
        {
            if (results[i].TryGetComponent(out animal)) 
            {
                Debug.Log(animal);
                break;
            }
        }

        if(animal != null)
        {
            //_charm.OnWear(animal);
            gameObject.SetActive(false);
            Debug.Log($"found animal {animal}");

            animal.OnCharmDrop += OnCharmDrop;
        }

        _layoutElemrnt.ignoreLayout = false;
    }

    private void OnCharmDrop(Charm obj)
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        if(_holding)
        {
            transform.position = Vector3.SmoothDamp(transform.position, Input.mousePosition, ref _velocity, 0.2f);
        }
    }
}
