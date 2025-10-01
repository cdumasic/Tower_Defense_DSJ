using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static List<Enemy> enemies = new List<Enemy>();

    public static void RegisterEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public static void UnregisterEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
    }
}
