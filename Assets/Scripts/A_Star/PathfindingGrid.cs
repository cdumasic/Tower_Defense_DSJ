using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class PathfindingGrid : MonoBehaviour
{
    public static PathfindingGrid Instance;

    [Header("Tilemaps")]
    public Tilemap groundTilemap;     
    public Tilemap obstacleTilemap;
    public Tilemap housesTilemap;
    public Tilemap towerBaseTilemap;

    public Node[,] grid;

    private BoundsInt bounds;

    private void Awake()
    {
        Instance = this;
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        bounds = groundTilemap.cellBounds;

        int width = bounds.size.x;
        int height = bounds.size.y;

        grid = new Node[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int cellPos = new Vector3Int(bounds.xMin + x, bounds.yMin + y, 0);
                Vector3 worldPos = groundTilemap.CellToWorld(cellPos) + new Vector3(0.5f, 0.5f);

                bool isWalkable = groundTilemap.HasTile(cellPos);

                if (obstacleTilemap.HasTile(cellPos) || towerBaseTilemap.HasTile(cellPos))
                    isWalkable = false;

                grid[x, y] = new Node(x, y, worldPos, isWalkable);
            }
        }

        Debug.Log("Grid generado: " + bounds.size.x + "x" + bounds.size.y);
    }

    public Node GetNodeFromWorld(Vector3 worldPos)
    {
        Vector3Int cell = groundTilemap.WorldToCell(worldPos);

        int x = cell.x - bounds.xMin;
        int y = cell.y - bounds.yMin;

        if (x >= 0 && y >= 0 && x < bounds.size.x && y < bounds.size.y)
            return grid[x, y];

        return null;
    }

    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        int[,] dirs = new int[,] {
            { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 }
        };

        for (int i = 0; i < 4; i++)
        {
            int nx = node.x + dirs[i, 0];
            int ny = node.y + dirs[i, 1];

            if (nx >= 0 && ny >= 0 && nx < grid.GetLength(0) && ny < grid.GetLength(1))
            {
                neighbours.Add(grid[nx, ny]);
            }
        }

        return neighbours;
    }

    public void SetNodeWalkable(Vector3 worldPos, bool walkable)
    {
        Node n = GetNodeFromWorld(worldPos);
        if (n != null)
            n.isWalkable = walkable;
    }
}

public class Node
{
    public int x, y;
    public Vector3 worldPos;
    public bool isWalkable;

    public Node parent;
    public int gCost, hCost;

    public int fCost => gCost + hCost;

    public Node(int x, int y, Vector3 worldPos, bool walkable)
    {
        this.x = x;
        this.y = y;
        this.worldPos = worldPos;
        this.isWalkable = walkable;
    }
}
