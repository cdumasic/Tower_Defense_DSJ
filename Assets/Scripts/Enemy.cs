using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints;  // puntos intermedios hacia el objetivo
    public Transform target;       // objetivo final (ej. jugador o base)
    public float speed = 2f;
    public float stopDistance = 2f; // distancia para detenerse si está cerca del objetivo

    private int currentIndex = 0;
    private bool isStopped = false;

    void Update()
    {
        if (isStopped) return;

        Transform destination;

        // Si aún hay waypoints pendientes, ir hacia ellos
        if (currentIndex < waypoints.Length)
        {
            destination = waypoints[currentIndex];
        }
        else
        {
            // Si ya pasó todos los waypoints → objetivo final
            destination = target;
        }

        // Mover hacia el destino
        transform.position = Vector2.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);

        // Verificar si llegó al waypoint actual
        if (Vector2.Distance(transform.position, destination.position) < speed * Time.deltaTime)
        {
            currentIndex++;
        }

        // Si está cerca del objetivo final → detenerse
        if (Vector2.Distance(transform.position, target.position) < stopDistance)
        {
            isStopped = true;
            Debug.Log("Enemigo se detuvo: objetivo detectado cerca");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Detenerse al chocar con algo
        isStopped = true;
        Debug.Log("Enemigo detenido por colisión con: " + collision.gameObject.name);
    }
    void OnEnable()
    {
        EnemyManager.RegisterEnemy(this);
    }

    void OnDisable()
    {
        EnemyManager.UnregisterEnemy(this);
    }
}
