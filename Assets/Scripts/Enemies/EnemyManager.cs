using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static List<Enemy> enemies = new List<Enemy>();

    void Awake()
    {
        enemies.Clear(); // limpia por si se recarga la escena
    }
}
