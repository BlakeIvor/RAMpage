using UnityEngine;


public class Enemy : MonoBehaviour
{
    GameManager gameManager;
    [Header("Enemy Variables")]
    [SerializeField] float health;
    [SerializeField] float baseDamage;
    [SerializeField] int Reward;

    public void Start()
    {
        gameManager = GameManager.instance;
    }

    public void Damage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameManager.updateCurrentMoney(Reward);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            Damage(gameManager.CalculateMovingDamage(player.prevVelocityX));
        }
    }
}
