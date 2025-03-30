using UnityEngine;

public class Wall : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] float health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Damage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement player) && this.gameObject.tag == "IntroWall")
        {
            gameManager.updateAllowInput(true);
            Damage(gameManager.CalculateMovingDamage(player.prevVelocityX));
            GameManager.instance.health -= 200;
        } 
        else if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement p))
        {
            Damage(gameManager.CalculateMovingDamage(p.prevVelocityX));
            GameManager.instance.health -= 200;
        }
    }
}
