using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Atributos básicos")]
    public float range = 3f;
    public float fireRate = 1f;
    public GameObject projectilePrefab;

    private float fireCooldown = 0f;
    private Enemy targetEnemy; // referencia directa al script del enemigo

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        // Buscar un nuevo objetivo si no hay o si el actual está fuera de rango
        if (targetEnemy == null || Vector2.Distance(transform.position, targetEnemy.transform.position) > range)
        {
            FindTarget();
        }

        // Si hay objetivo válido y puede disparar
        if (targetEnemy != null && fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }
    }

    void FindTarget()
    {
        Enemy nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;
        foreach (Enemy enemy in EnemyManager.enemies)
        {
            if (enemy == null) continue;

            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance && distance <= range)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        targetEnemy = nearestEnemy;
    }

    void Shoot()
    {
        if (projectilePrefab == null || targetEnemy == null) return;

        GameObject projectileGO = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Bullet projectile = projectileGO.GetComponent<Bullet>();

        if (projectile != null)
        {
            projectile.SetTarget(targetEnemy.transform);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
