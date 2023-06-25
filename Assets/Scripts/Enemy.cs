using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    private const string Speed = "Speed";

    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(_target != null)
        {
            Vector3 direction =_target.position - transform.position;

            if (direction.normalized.x > 0)
            {
                _spriteRenderer.flipX = false;
                _animator.SetFloat(Speed, _speed);
                transform.Translate(_speed * Time.deltaTime, 0, 0);
            }
            else if (direction.normalized.x < 0)
            {
                _spriteRenderer.flipX = true;
                _animator.SetFloat(Speed, _speed);
                transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            }

            transform.Translate(direction.normalized.x * _speed * Time.deltaTime, 0, 0);
        }
    }

    public void SetTarget(Transform player)
    {
        _target = player;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);

            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
