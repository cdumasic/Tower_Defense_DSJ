using System.Collections.Generic;
using UnityEngine;

public class FishFlockingAgent : MonoBehaviour
{
    public static float globalSeed = 1234f;

    [Header("Pesos base")]
    public float baseCohesion = 1f;
    public float baseAlignment = 1f;
    public float baseSeparation = 1.5f;

    [Header("Variación de flocking")]
    public float variationSpeed = 0.3f;        // Qué tan rápido cambian los valores
    public float variationAmount = 0.5f;        // Qué tanto varían

    private EnemyPathfinding2 movement;
    private FishFlockManager manager;

    private float seed;

    void Start()
    {
        movement = GetComponent<EnemyPathfinding2>();
        manager = FishFlockManager.Instance;
        manager.Register(this);

        // variación suave del mismo cardumen
        seed = globalSeed + Random.Range(-2f, 2f);
    }

    float GetDynamicValue(float baseValue, float tOffset)
    {
        float noise = Mathf.PerlinNoise(seed + tOffset, Time.time * variationSpeed);
        noise = (noise - 0.5f) * 2f; // -1 a 1
        return baseValue + noise * variationAmount;
    }

    public Vector3 GetFlockingDirection()
    {
        var agents = manager.agents;
        if (agents.Count <= 1)
            return Vector3.zero;

        Vector3 cohesion = Vector3.zero;
        Vector3 alignment = Vector3.zero;
        Vector3 separation = Vector3.zero;

        int count = 0;

        foreach (var other in agents)
        {
            if (other == this) continue;

            float dist = Vector3.Distance(transform.position, other.transform.position);
            if (dist < 10f)
            {
                cohesion += other.transform.position;
                alignment += other.movement.GetDirection();

                if (dist < 1f)
                    separation += (transform.position - other.transform.position) / dist;

                count++;
            }
        }

        if (count > 0)
        {
            cohesion = ((cohesion / count) - transform.position).normalized;
            alignment = (alignment / count).normalized;
        }

        float cohesionW = GetDynamicValue(baseCohesion, 1.3f);
        float alignmentW = GetDynamicValue(baseAlignment, 2.7f);
        float separationW = GetDynamicValue(baseSeparation, 3.9f);

        return cohesion * cohesionW +
               alignment * alignmentW +
               separation * separationW;
    }
}
