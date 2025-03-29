using UnityEngine;
public class Archer : Enemy
{
    [SerializeField] GameObject projectile;
    private float Targetx;
    private float Targety;
    public float minDeviation;
    public float maxDeviation;
    
    override public void attack()
    {
        GameObject Bullet = Instantiate(projectile, transform.position, Quaternion.identity);
        
        Targety = (GameObject.FindWithTag("Player").transform.position.y);
        
        Targety -= transform.position.y;

        Targety += Random.Range(minDeviation, maxDeviation);
        
        Targetx = (GameObject.FindWithTag("Player").transform.position.x);
        
        Targetx -= transform.position.x;
        
        Targetx += Random.Range(minDeviation, maxDeviation);

        Bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(Targetx, Targety).normalized;
        Bullet.GetComponent<Arrow>().lifetime = 1;
        Bullet.GetComponent<Arrow>().damage = baseDamage;
        StartCoroutine(AttackCooldown());
    }

    public override void Update()
    {
        if (CanAttack)
        {
            CanAttack = false;
            attack();
        }
    }
}
