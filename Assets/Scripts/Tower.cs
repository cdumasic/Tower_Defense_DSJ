using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 3f;
    public float fireRate = 1f;
    public GameObject projectilePrefab;
    private float fireCooldown = 0f;

    private Transform target;

    void Update()
    {
        // Buscar enemigo más cercano en rango
        Enemy[] enemies = EnemyManager.enemies.ToArray();
        float shortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (Enemy enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance && distance <= range)
            {
                shortestDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }

        target = nearestEnemy;

        // Disparar si hay enemigo
        if (target != null)
        {
            if (fireCooldown <= 0f)
            {
                Shoot();
                fireCooldown = 1f / fireRate;
            }
        }

        fireCooldown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject projectileGO = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Bullet projectile = projectileGO.GetComponent<Bullet>();
        if (projectile != null)
        {
            projectile.SetTarget(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // Color del círculo
        Gizmos.DrawWireSphere(transform.position, range); // Dibuja el radio
    }
}
