using System.Collections.Generic;
using UnityEngine;

public class AStarPathfinder : MonoBehaviour
{
    public static AStarPathfinder Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<Vector3> FindPath(Vector3 startWorld, Vector3 endWorld)
    {
        Node startNode = PathfindingGrid.Instance.GetNodeFromWorld(startWorld);
        Node endNode = PathfindingGrid.Instance.GetNodeFromWorld(endWorld);

        if (startNode == null || endNode == null)
            return null;

        List<Node> open = new List<Node>();
        HashSet<Node> closed = new HashSet<Node>();

        open.Add(startNode);

        while (open.Count > 0)
        {
            Node current = open[0];
            for (int i = 1; i < open.Count; i++)
            {
                if (open[i].fCost < current.fCost)
                    current = open[i];
            }

            open.Remove(current);
            closed.Add(current);

            if (current == endNode)
                return RetracePath(startNode, endNode);

            foreach (Node neighbour in PathfindingGrid.Instance.GetNeighbours(current))
            {
                if (!neighbour.isWalkable || closed.Contains(neighbour))
                    continue;

                int newCost = current.gCost + 10;

                if (newCost < neighbour.gCost || !open.Contains(neighbour))
                {
                    neighbour.gCost = newCost;
                    neighbour.hCost = Heuristic(neighbour, endNode);
                    neighbour.parent = current;

                    if (!open.Contains(neighbour))
                        open.Add(neighbour);
                }
            }
        }

        return null;
    }

    int Heuristic(Node a, Node b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
    }

    List<Vector3> RetracePath(Node start, Node end)
    {
        List<Vector3> path = new List<Vector3>();
        Node current = end;

        while (current != start)
        {
            path.Add(current.worldPos);
            current = current.parent;
        }

        path.Reverse();
        return path;
    }
}

