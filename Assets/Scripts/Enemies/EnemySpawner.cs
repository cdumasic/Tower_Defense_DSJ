using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configuración de oleadas")]
    public GameObject enemyPrefab;       // Prefab del enemigo a generar
    public Transform spawnPoint;         // Punto donde aparecen
    public int enemiesPerWave = 5;       // Enemigos por oleada
    public float timeBetweenEnemies = 15f; // Tiempo entre cada enemigo
    public float timeBetweenWaves = 50f;   // Tiempo entre oleadas

    private int currentWave = 0;
    private bool isSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            currentWave++;
            isSpawning = true;

            Debug.Log($"Iniciando oleada {currentWave}");

            // Generar enemigos de esta oleada
            for (int i = 0; i < enemiesPerWave; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(timeBetweenEnemies);
            }

            isSpawning = false;
            Debug.Log($"Oleada {currentWave} finalizada. Esperando {timeBetweenWaves} segundos...");

            // Esperar antes de la siguiente oleada
            yield return new WaitForSeconds(timeBetweenWaves);

            // Escalar dificultad (opcional)
            enemiesPerWave += 1; // Aumenta enemigos cada ronda
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
