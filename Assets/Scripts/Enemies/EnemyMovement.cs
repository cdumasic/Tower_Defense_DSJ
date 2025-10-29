using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public WaypointPath path;
    public float speed = 2f;
    public int rotationY = 180;
    private int currentWaypointIndex = 0;
    private Enemy enemy;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, rotationY, 0);
        enemy = GetComponent<Enemy>();

        if (path == null)
            path = FindFirstObjectByType<WaypointPath>();

        transform.position = path.GetWaypoint(0).position;
    }

    void Update()
    {
        MoveAlongPath();
    }

    void MoveAlongPath()
    {
        if (path == null || path.GetWaypointCount() == 0)
            return;

        Transform targetWaypoint = path.GetWaypoint(currentWaypointIndex);
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= path.GetWaypointCount())
            {
                // 🔹 ahora delegamos la lógica de fin de camino al script Enemy
                enemy.ReachEnd();
            }
        }
    }
}
