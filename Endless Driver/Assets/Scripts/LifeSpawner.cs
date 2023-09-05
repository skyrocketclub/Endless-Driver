using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpawner : MonoBehaviour
{
    public GameObject lifePrefab;
    public static bool spawnLife = false;
    private float spawnRangeX = 8.0f;
    private float spawnPosZ = 0f;

    void Update()
    {
        if(spawnLife == true)
        {
            SpawnLife();
            spawnLife = false;
        }
    }

    private void SpawnLife()
    {
        Debug.Log("Heart Spawned...");
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(lifePrefab, spawnPos, lifePrefab.transform.rotation);
    }
}
