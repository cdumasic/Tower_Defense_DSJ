using UnityEngine;
using System.Collections.Generic;

public class EnemyPathfinding2 : MonoBehaviour
{
    public float speed = 2f;
    private float speedVariation;

    public WaypointPath waypoints;

    private Transform startPoint;
    private Transform endPoint;
    private List<Vector3> path;
    private int pathIndex = 0;

    private Enemy enemy;
    private FishFlockingAgent flockAgent;

    private Vector3 lastDirection = Vector3.right; 

    void Start()
    {
        if (waypoints == null)
        {
            GameObject obj = GameObject.Find("WaypointPath");
            if (obj != null)
                waypoints = obj.GetComponent<WaypointPath>();
        }

        if (waypoints == null)
        {
            return;
        }

        speedVariation = Random.Range(0.85f, 1.15f); //15% de velocidad

        startPoint = waypoints.GetWaypoint(0);
        endPoint = waypoints.GetWaypoint(waypoints.GetWaypointCount()-1);

        enemy = GetComponent<Enemy>();
        flockAgent = GetComponent<FishFlockingAgent>();

        path = AStarPathfinder.Instance.FindPath(startPoint.position, endPoint.position);

        CalculatePath();
    }

    void Update()
    {
        FollowPath();
    }

    void CalculatePath()
    {
        pathIndex = 0;

        if (path == null || path.Count == 0)
        {
            Debug.LogWarning("¡No hay camino disponible!");
        }
    }

    public Vector3 GetDirection()
    {
        // Si tenemos un objetivo válido en el path usamos esa dirección preferentemente
        if (path != null && pathIndex < path.Count)
        {
            Vector3 target = path[pathIndex];
            Vector3 dir = (target - transform.position);
            if (dir.sqrMagnitude > 0.0001f)
                return dir.normalized;
        }

        // Si no hay target o la distancia es muy pequeña, devolvemos la última dirección conocida
        if (lastDirection.sqrMagnitude > 0.0001f)
            return lastDirection.normalized;

        return Vector3.right; // fallback seguro
    }
    void FollowPath()
    {
        if (path == null || pathIndex >= path.Count)
            return;

        Vector3 target = path[pathIndex];

        // 1️⃣ Dirección base del A*
        Vector3 aStarDirection = (target - transform.position).normalized;

        // 2️⃣ Dirección de flocking (si existe el agente)
        Vector3 flockDirection = Vector3.zero;
        if (flockAgent != null)
            flockDirection = flockAgent.GetFlockingDirection();

        // 3️⃣ DIRECCIÓN FINAL combinada
        Vector3 finalDirection = (aStarDirection + flockDirection).normalized;

        // 4️⃣ Movimiento REAL usando la nueva dirección
        transform.position += finalDirection * (speed * speedVariation) * Time.deltaTime;

        if (finalDirection.sqrMagnitude > 0.0001f)
            lastDirection = finalDirection;

        // 5️⃣ Check de llegada al waypoint
        if (Vector2.Distance(transform.position, target) < 0.3f)
        {
            pathIndex++;

            if (pathIndex >= path.Count)
                enemy.ReachEnd();
        }
    }
}
