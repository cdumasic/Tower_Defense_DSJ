using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;
    private Transform target;
    private Enemy targetEnemy;


    public void SetTarget(Transform enemy)
    {
        target = enemy;
        targetEnemy = enemy.GetComponent<Enemy>();
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // Mover la bala hacia el objetivo
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Cuando impacta
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            if (targetEnemy != null)
            {
                targetEnemy.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
