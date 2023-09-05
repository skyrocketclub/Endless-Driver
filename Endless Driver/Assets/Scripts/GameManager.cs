using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float startTime;
    private string formattedTime;
    public static bool timerActive = false;
    public static int lives;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI durationText;
    public GameObject spawnManager;
    public GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        timerActive = true;
        startTime = Time.time;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive)
        {
            UpdateTime();
            UpdateLives();
        }
    }

    private void UpdateTime()
    {
        float currentTime = Time.time - startTime;
        int hours = (int)(currentTime / 3600);
        int minutes = (int)((currentTime % 3600) / 60);
        int seconds = (int)(currentTime % 60);

        formattedTime = string.Format("{0:D2} : {1:D2} : {2:D2} ", hours, minutes, seconds);
        timeText.text = formattedTime;
    }

    private void UpdateLives()
    {
        if(lives == 0)
        {
            string livesString;
            livesString = "Lives: 0";
            livesText.text = livesString;
            GameOver();
        }
        else
        {
            string livesString;
            livesString = "Lives: " + lives.ToString();
            livesText.text = livesString;
            if(lives == 1)
            {
                GameObject[] heartObjects = GameObject.FindGameObjectsWithTag("Heart");
                if(heartObjects.Length == 0)
                {
                    LifeSpawner.spawnLife = true; //Spawn a life to give user a chance...
                } 
            }
        }
    }

    private void GameOver()
    {
        //end vehicle spawn, activate GameOver Canvas...
        timerActive=false;
        SpawnManager.keepSpawning = false;
        gameOverCanvas.gameObject.SetActive(true);
        durationText.text = "Duration: " + formattedTime;
    }
}
