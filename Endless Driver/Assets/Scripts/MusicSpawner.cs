using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSpawner : MonoBehaviour
{
   // public AudioClip[] soundTracks;
    public GameObject musicPrefab;
    private float spawnRangeX = 8.0f;
    private float spawnPosZ = 0f;
    private float startDelay = 3f;
    private float spawnInterval = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMusicObject", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.timerActive)
        {
            
        }
        else
        {
            CancelInvoke("SpawnMusicObject");
        }
    }

    private void SpawnMusicObject()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0.475f, spawnPosZ);
        Instantiate(musicPrefab, spawnPos, musicPrefab.transform.rotation);
        PlayRandomMusic.changeIncomingTrack = true;
    }
}
