using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float startTime;
    private string formattedTime;
    public static int score;
    public static bool timerActive = false;
    public static int lives;
    public static bool hasPowerup = false;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI durationText;
    public TextMeshProUGUI scoreText;
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
        UpdateScore();
        ApproachPlayer.speed += 0.01f;
        //SpawnManager.spawnInterval -= 0.05f;
       // Debug.Log(SpawnManager.spawnInterval);
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

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        spawnManager.gameObject.SetActive(true);
        SpawnManager.restartSpawning = true;
        SpawnManager.keepSpawning = true;
        score = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
