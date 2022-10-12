using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;

   

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)&& isGameOver==true)
        {
            SceneManager.LoadScene("Game");
        }
        
        ExitManager();
    }

    public void GameOver()
    {
        isGameOver = true;
    }

    public void ExitManager()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    
    
}
