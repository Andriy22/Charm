using UnityEngine;

public class AnimalAnimations : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private AnimalMovement _movement;

    public void OnAttack()
    {
        _animator.SetTrigger("attack");
    }

    private void FixedUpdate() 
    {
        _spriteRenderer.flipX = _movement.Velocity.x < 0;
        _animator.SetFloat("speed", _rigidbody.velocity.magnitude); 
    }
}