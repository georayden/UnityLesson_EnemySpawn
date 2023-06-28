using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class PlayerMover : PhysicsMovement
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpVelocity;

    private const string Speed = "Speed";

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
        
    private void Update()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");

        TargetVelocity = new Vector2(horizontalDirection * _speed, 0);

        if (horizontalDirection > 0)
        {
            _spriteRenderer.flipX = false;
            _animator.SetFloat(Speed, horizontalDirection);
        }
        else
        {
            _spriteRenderer.flipX = true;
            _animator.SetFloat(Speed, horizontalDirection * -1);
        }  

        if (Input.GetKey(KeyCode.Space) && Grounded)
            Velocity.y = _jumpVelocity;        
    }
}
