using UnityEngine;

public class EnemyMovement : MonoBehaviour, IEnemyPart
{
    private Enemy _enemy;
    public Enemy Enemy => _enemy;

    private Rigidbody2D _rigidbody2D;
    private Vector3 center;

    [SerializeField] private float _speed = 1f;

    public void SetUp(Enemy enemy)
    {
        _enemy = enemy;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        center = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if(Enemy.Stunned)
        {
            return;
        }

        Move();
    }

    private void Move()
    {
        Vector3 direction = (MainAnimal.Animal.transform.position - transform.position).normalized;
        Vector3 velocity = direction * (Enemy?.Stats.Speed ?? _speed);

        _rigidbody2D.velocity = velocity;
    }
}