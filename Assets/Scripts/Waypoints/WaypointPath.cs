using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    public Transform[] waypoints;

    void Awake()
    {
        // Obtener todos los hijos automáticamente
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }

    public Transform GetWaypoint(int index)
    {
        if (index < 0 || index >= waypoints.Length)
            return null;
        return waypoints[index];
    }

    public int GetWaypointCount()
    {
        return waypoints.Length;
    }
}
