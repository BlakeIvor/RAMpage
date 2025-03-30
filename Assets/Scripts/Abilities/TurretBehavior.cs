using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    [SerializeField] float radius = 20;
    [SerializeField] float cooldown = 8;
    [SerializeField] float damage = 200;
    [SerializeField] float lineDuration = 3;
    [SerializeField] LineRenderer linePrefab;

    private float lastShotTime = -Mathf.Infinity;

    void Start()
    {
        linePrefab = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Time.time >= lastShotTime + cooldown)
        {
            DetectAndShoot();
        }
    }

    private void DetectAndShoot()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, radius))
        {
            if (collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                ShootEnemy(enemy);
                break;
            }
            else if (collider.TryGetComponent<Wall>(out Wall wall))
            {
                ShootWall(wall);
                break;
            }
        }
    }

    private void ShootEnemy(Enemy enemy)
    {
        enemy.Damage(damage);
        StartLaser(enemy.transform.position);
        lastShotTime = Time.time;
    }

    private void ShootWall(Wall wall)
    {
        wall.Damage(damage);
        StartLaser(wall.transform.position);
        lastShotTime = Time.time;
    }

    private void StartLaser(Vector3 targetPosition)
    {
        linePrefab.enabled = true;
        linePrefab.SetPosition(0, transform.position);
        linePrefab.SetPosition(1, targetPosition);
        Invoke("StopLaser", lineDuration);
    }

    private void StopLaser()
    {
        linePrefab.enabled = false;
    }
}
