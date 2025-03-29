using UnityEngine;
using System.Collections;


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
    [SerializeField] float AttackRadius;
    private GameObject Player;
    public EnemyObject Type;
    [SerializeField] bool CanAttack;

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
    }

    public void attack()
    {
        if (CanAttack)
        {
            CanAttack = false;
            StartCoroutine(AttackCooldown());
            Debug.Log("Attacked");
        }
    }

    private void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, step);
        if (Physics2D.OverlapCircle(transform.position, AttackRadius).TryGetComponent<PlayerMovement>(out PlayerMovement player))
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
