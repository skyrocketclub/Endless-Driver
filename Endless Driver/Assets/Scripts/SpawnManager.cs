using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject powerupPrefab;
    public GameObject[] enemyPrefab;
    public static bool keepSpawning = true;
    public static bool restartSpawning = false;
    public static float spawnInterval = 0.6f; //decreases as the intensity increases for Game Mechanics
    private float spawnRangeX = 8.0f;
    private float spawnPosZ = -200.0f;
    private float startDelay = 3f;
 
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
        StartCoroutine(SpawnPowerupRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (!keepSpawning)
        {
            CancelInvoke("SpawnRandomEnemy");
        }
        if (restartSpawning)
        {
            RestartSpawning();
        }

    }

    void SpawnRandomEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefab.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(enemyPrefab[enemyIndex], spawnPos, enemyPrefab[enemyIndex].transform.rotation);
        GameManager.score+=1;
    }

    void SpawnPowerup()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0.625f, spawnPosZ);
        Instantiate(powerupPrefab, spawnPos, powerupPrefab.transform.rotation);
        StartCoroutine(SpawnPowerupRoutine());
        Debug.Log("Powerup Spawned!!!");
    }

    IEnumerator SpawnPowerupRoutine()
    {
        yield return new WaitForSeconds(15);
        SpawnPowerup();
    }
    
    void RestartSpawning()
    {
        restartSpawning = false;
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
    }
}
