using UnityEngine;


public class Enemy : MonoBehaviour
{
    GameManager gameManager;
    [Header("Enemy Variables")]
    [SerializeField] float health;
    [SerializeField] float baseDamage;
    [SerializeField] float cooldown;
    [SerializeField] int Reward;
    [SerializeField] Collider2D Hitbox;
    [SerializeField] float speed;
    private GameObject Player;
    public EnemyObject Type;

    public void Start()
    {
        gameManager = GameManager.instance;
        health = Type.health;
        baseDamage = Type.damage;
        Reward = Type.reward;
        speed = Type.speed;
        

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

    private void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, step);
    }

}
