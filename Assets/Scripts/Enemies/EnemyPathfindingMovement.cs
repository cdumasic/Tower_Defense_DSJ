using UnityEngine;
using System.Collections.Generic;

public class EnemyPathfindingMovement : MonoBehaviour
{
    public float speed = 2f;
    public WaypointPath waypoints;
    private Transform startPoint;
    private Transform endPoint;

    private List<Vector3> path;
    private int pathIndex = 0;
    private Enemy enemy;

    void Start()
    {
        if (waypoints == null)
            waypoints = FindFirstObjectByType<WaypointPath>();

        startPoint = waypoints.GetWaypoint(1);
        endPoint = waypoints.GetWaypoint(waypoints.GetWaypointCount()-2);

        enemy = GetComponent<Enemy>();
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

    void FollowPath()
    {
        if (path == null || pathIndex >= path.Count)
            return;

        Vector3 target = path[pathIndex];
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            pathIndex++;

            if (pathIndex >= path.Count)
                enemy.ReachEnd();
        }
    }
}

