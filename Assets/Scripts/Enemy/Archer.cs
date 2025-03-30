using UnityEngine;
public class Archer : Enemy
{
    [SerializeField] GameObject projectile;
    private float Targetx;
    private float Targety;
    public float minDeviation;
    public float maxDeviation;
    [SerializeField] private float arrowSpeed;
    private Transform player;
    public float AttackRadius;
    override public void attack()
    {
        float distanceX = Mathf.Abs(player.position.x - transform.position.x);
        
        if (distanceX <= AttackRadius) {
            GameObject Bullet = Instantiate(projectile, transform.position, Quaternion.identity);
            Transform target = GameObject.FindWithTag("Player").transform;

            Vector3 directionVector = (target.position - transform.position).normalized;

            Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = directionVector * arrowSpeed;
            float angle = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg;
            Bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

            StartCoroutine(AttackCooldown());
        }
    }


    public override void Update()
    {
        if (!player) player = GameObject.Find("PlayerBase").transform;
        if (CanAttack)
        {
            CanAttack = false;
            attack();
        }
    }
}
