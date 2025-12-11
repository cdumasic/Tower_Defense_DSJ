using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configuración de oleadas")]
    public GameObject enemyPrefab;       // Prefab del enemigo a generar
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;

    public Transform spawnPoint;         // Punto donde aparecen
    public int enemiesPerWave = 5;       // Enemigos por oleada

    [Header("Orda 1")]
    public float timeBetweenEnemies1 = 10f; // Tiempo entre cada enemigo
    public float timeBetweenWaves1 = 50f;   // Tiempo entre oleadas

    [Header("Orda 2")]
    public float timeBetweenEnemies2 = 5f; // Tiempo entre cada enemigo
    public float timeBetweenWaves2 = 60f;   // Tiempo entre oleadas


    private int currentWave = 0;
    private bool isSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (currentWave < 3)
        {
            currentWave++;
            isSpawning = true;

            GameManager.Instance.setMessage($"Iniciando oleada {currentWave}");
            GameManager.Instance.setOrda(currentWave);

            if(currentWave == 1)
            {
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    SpawnEnemy1();
                    yield return new WaitForSeconds(timeBetweenEnemies1);
                }
                isSpawning = false;
                GameManager.Instance.setMessage($"Oleada {currentWave} finalizada. Esperando {timeBetweenWaves1} segundos...");
                yield return new WaitForSeconds(timeBetweenWaves1);
            }
            if (currentWave == 2)
            {
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    SpawnEnemy2();
                    yield return new WaitForSeconds(timeBetweenEnemies2);
                }
                isSpawning = false;
                GameManager.Instance.setMessage($"Oleada {currentWave} finalizada. Esperando {timeBetweenWaves2} segundos...");
                yield return new WaitForSeconds(timeBetweenWaves2);
            }
            if (currentWave == 3)
            {
                SpawnEnemy3();
                isSpawning = false;
            }
        }
    }

    void SpawnEnemy1()
    {
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }

    void SpawnEnemy2()
    {
        Instantiate(enemyPrefab2, spawnPoint.position, Quaternion.identity);
    }
    void SpawnEnemy3()
    {
        Instantiate(enemyPrefab3, spawnPoint.position, Quaternion.identity);
    }
}
