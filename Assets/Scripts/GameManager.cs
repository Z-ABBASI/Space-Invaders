using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private int score;
    private int highScore;
    public GameObject enemy10;
    public GameObject enemy20;
    public GameObject enemy30;
    public GameObject enemyMystery;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        
        // Instantiate Enemies
        for (float x = 0f; x < 11f; x++)
        {
            Instantiate(enemy10, new Vector3(x, 0, 0), Quaternion.identity);
            Instantiate(enemy10, new Vector3(x, 1, 0), Quaternion.identity);
            Instantiate(enemy20, new Vector3(x, 2, 0), Quaternion.identity);
            Instantiate(enemy20, new Vector3(x, 3, 0), Quaternion.identity);
            Instantiate(enemy30, new Vector3(x, 4, 0), Quaternion.identity);
            if (x != 0)
            {
                Instantiate(enemy10, new Vector3(-x, 0, 0), Quaternion.identity);
                Instantiate(enemy10, new Vector3(-x, 1, 0), Quaternion.identity);
                Instantiate(enemy20, new Vector3(-x, 2, 0), Quaternion.identity);
                Instantiate(enemy20, new Vector3(-x, 3, 0), Quaternion.identity);
                Instantiate(enemy30, new Vector3(-x, 4, 0), Quaternion.identity);
            }
            
        }
        
        // Death of Enemies
        Enemy.OnEnemyDied += EnemyOnOnEnemyDies;
        void EnemyOnOnEnemyDies(int points)
        {
            score += points;
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
