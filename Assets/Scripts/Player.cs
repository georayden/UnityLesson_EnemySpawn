using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int Health = 5;

    private Wallet _wallet;

    private void Start()
    {
        _wallet = GetComponent<Wallet>();
    }

    private void Update()
    {
        if(Health <= 0)
        {
            Die();
        }
    }    

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Coin>(out Coin coin))
        {
            _wallet.TakeCoin(coin.Amount);
            coin.Disable();
        }
    }
}
