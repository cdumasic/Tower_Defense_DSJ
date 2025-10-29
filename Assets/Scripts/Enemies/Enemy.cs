using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Atributos del enemigo")]
    public EnemyHealthBar EnemyHealthBar;
    public int maxHealth = 5;
    private int currentHealth;

    [Header("Recompensas")]
    public int goldReward = 10;
    public int scoreReward = 20;
    public int lifePenalty = 1;

    private EnemyMovement movement;

    void Start()
    {
        currentHealth = maxHealth;
        EnemyHealthBar.UpdateHealthBar(maxHealth, currentHealth);
        // Se registra en el manager
        if (!EnemyManager.enemies.Contains(this))
            EnemyManager.enemies.Add(this);

        // Obtiene referencia al movimiento (por si lo necesitas luego)
        movement = GetComponent<EnemyMovement>();
    }

    void OnDisable()
    {
        EnemyManager.enemies.Remove(this);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        EnemyHealthBar.UpdateHealthBar(maxHealth, currentHealth);
        Debug.Log($"{gameObject.name} recibió {damage} de daño. Salud restante: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} ha muerto");

        // Otorgar recompensas
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddGold(goldReward);
            GameManager.Instance.AddScore(scoreReward);
        }

        EnemyManager.enemies.Remove(this);
        Destroy(gameObject);
    }

    public void ReachEnd()
    {
        Debug.Log($"{gameObject.name} llegó al final del camino!");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.LoseLife(lifePenalty);
        }

        Destroy(gameObject);
    }
}
