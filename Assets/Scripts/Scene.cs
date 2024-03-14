using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    private void Start()
    {
        // Played Credits
        Credits.OnFiveSeconds += CreditsOnOnFiveSeconds;
        void CreditsOnOnFiveSeconds()
        {
            LoadScene("Menu");
        }
        
        // Death of Player
        Player.OnPlayerDied += PlayerOnOnPlayerDies;
        void PlayerOnOnPlayerDies()
        {
            LoadScene("Credits");
        }
        
        // Victory
        GameManager.OnVictory += GameManagerOnOnVictory;
        void GameManagerOnOnVictory()
        {
            LoadScene("Credits");
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        SceneManager.UnloadSceneAsync(scene);
    }
}
