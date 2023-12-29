using UnityEngine;

public class AnimalMovement : MonoBehaviour, IAnimalPart
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _distance = 1f;
    [SerializeField] private float _timeToChangeDestination = 2f;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _destination;
    private float _timer;
    private Animal _animal;

    public Animal Animal => _animal;

    public void SetUp(Animal animal)
    {
        _animal = animal;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        SetRandomDestination();
    }
   
    private void FixedUpdate()
    {
        MoveToDestination();
    }

    private void MoveToDestination()
    {
        float distanceToDestination = Vector2.Distance(transform.position, _destination);

        if (distanceToDestination < 0.1f)
        {
            SetRandomDestination();
            return;
        }

        _timer += Time.fixedDeltaTime;

        if (_timer > _timeToChangeDestination) 
        {
            SetRandomDestination();
            return;
        }

        float progress = Mathf.Clamp01(_timer / _timeToChangeDestination);

        Vector2 direction = (_destination - (Vector2)transform.position).normalized;
        Vector2 velocity = direction * _speed * progress;

        _rigidbody2D.velocity = velocity;
    }

    private void SetRandomDestination()
    {
        var randomOffset = Random.insideUnitCircle * _distance;
        _destination = randomOffset;
        _timer = 0f;
    }
}
