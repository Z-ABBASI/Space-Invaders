using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Score Text
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    
    // Score
    private int score;
    private int highScore;
    
    // Delegate And Event
    public delegate void Victory();
    public static event Victory OnVictory;
    
    // Number Of Enemies
    public int numberOfEnemies;
    
    // Start is called before the first frame update
    void Start()
    {
        // direction = Vector3.left;
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        
        // Death of Enemies
        Enemy.OnEnemyDied += EnemyOnOnEnemyDies;
        void EnemyOnOnEnemyDies(int points)
        {
            score += points;
            numberOfEnemies--;
            if (numberOfEnemies <= 0)
            {
                OnVictory.Invoke();
            }
        }
        
        // Death of Player
        Player.OnPlayerDied += PlayerOnOnPlayerDies;
        void PlayerOnOnPlayerDies()
        {
            SaveHighScore();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Score Text
        scoreText.text = "SCORE\n";
        if(score < 1000)
        {
            scoreText.text += "0";
        }

        if (score < 100)
        {
            scoreText.text += "0";
        }

        if (score < 10)
        {
            scoreText.text += "0";
        }

        scoreText.text += score;
        
        // High Score Text
        highScoreText.text = "HI-SCORE\n";
        if(highScore < 1000)
        {
            highScoreText.text += "0";
        }

        if (highScore < 100)
        {
            highScoreText.text += "0";
        }

        if (highScore < 10)
        {
            highScoreText.text += "0";
        }

        highScoreText.text += highScore;
    }

    public void SaveHighScore()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save(); // Save the changes
        }
    }
}
