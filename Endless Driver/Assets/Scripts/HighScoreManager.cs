using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class HighScoreManager : MonoBehaviour
{
   // public TextAsset highScoreTextFile; //Reference to the text file in Resources folder
    public TextMeshProUGUI highScoreText; // Text Mesh component to display high score in gmae
    public TMP_InputField playerNameInputPanel;
    public GameObject highScorePanel;
    public GameObject buttons;
  //  public TextMeshProUGUI playerName;
    private int currentHighScore;
    private string currentChampion;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        currentHighScore =  LoadHighScore();
        DisplayHighScore(currentHighScore);
    }

    void Update()
    {
        score = GameManager.score; 
        if(GameManager.timerActive == false && GameManager.lives == 0)
        {
            if (currentHighScore > score)
            {
                //Update the high score when necessary if the game is over.
                DoNotUpdateHighScore();
            }
            else
            {
                //Since you will be updating highScore...
                buttons.SetActive(false);
            }
        }
    }


    void DoNotUpdateHighScore()
    {
            highScorePanel.gameObject.SetActive(false);
    }

    //on Submit button clicked
    public void SaveHighScore()
    {
        string playerName = playerNameInputPanel.text;
        if (!string.IsNullOrEmpty(playerName))
        {
            SaveHighScore(playerName, score);
            highScorePanel.gameObject.SetActive(false);
            // Set the Replay Button & Quit button to be both visible...
            buttons.SetActive(true);
        }
    }

    //Gets the High Score from the file at the begining of the gameplay
    private int LoadHighScore()
    {
        //Load the high score from the text file
        // TextAsset highScoreFile = Resources.Load<TextAsset>("highscores");
        //string[] lines = highScoreFile.text.Split('\n');
        string filePath = "Assets/Resources/highscores.txt";
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            if(lines.Length > 0)
            {
                string[] parts = lines[0].Split(':');
                if (parts.Length == 2)
                {
                    currentChampion = parts[0];
                    return int.Parse(parts[1].Trim());
                }
            }
            
        }
        return 0;
    }

    private void SaveHighScore(string playerName, int score)
    {
        string newHighScore = playerName + ": " + score;
        File.WriteAllText("Assets/Resources/highscores.txt", newHighScore); 
    }

    private void DisplayHighScore(int score)
    {
        highScoreText.text = "High Score: " + currentChampion + " : " + score;
    }
}
