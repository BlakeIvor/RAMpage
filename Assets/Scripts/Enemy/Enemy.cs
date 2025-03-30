using UnityEngine;
using System.Collections;


public class Enemy : MonoBehaviour
{
    GameManager gameManager;
    [Header("Enemy Variables")]
    [SerializeField] public float health;
    [SerializeField] public float baseDamage;
    [SerializeField] public float cooldown;
    [SerializeField] int Reward;
    [SerializeField] Collider2D Hitbox;
    [SerializeField] float speed;
    [SerializeField] float Radius;
    private GameObject Player;
    public EnemyObject Type;
    public bool CanAttack = true;

    public void Start()
    {
        gameManager = GameManager.instance;
        health = Type.health;
        baseDamage = Type.damage;
        Reward = Type.reward;
        speed = Type.speed;
        Player = GameObject.FindWithTag("Player");

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
        if (collision.TryGetComponent<MagicBallBehavior>(out MagicBallBehavior magicBallBehavior))
        {
            Damage(magicBallBehavior.damage);
        }
    }

    public virtual void attack()
    {
        if (CanAttack)
        {
            CanAttack = false;
            StartCoroutine(AttackCooldown());
            Debug.Log("Attacked");
        }
    }

    public virtual void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, step);
        if (Physics2D.OverlapCircle(transform.position, Radius).TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            attack();
        }
    }

    public IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        CanAttack = true;
    }
}
