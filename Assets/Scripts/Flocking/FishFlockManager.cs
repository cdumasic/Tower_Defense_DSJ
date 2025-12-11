using System.Collections.Generic;
using UnityEngine;

public class FishFlockManager : MonoBehaviour
{
    public static FishFlockManager Instance;

    public List<FishFlockingAgent> agents = new();

    void Awake()
    {
        Instance = this;
    }

    public void Register(FishFlockingAgent agent)
    {
        agents.Add(agent);
    }
}

