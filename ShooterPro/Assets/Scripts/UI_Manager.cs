using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Image livesImage;

    [SerializeField] private Text gameOverText,restartText;
    
    
    [SerializeField] private Sprite[] livesSprite;

    
    

    private Player _player;
    private GameManager _gameManager;

    
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _player = FindObjectOfType<Player>();
        gameOverText.gameObject.SetActive(false);
        restartText.gameObject.SetActive(false);
    }

    
    void Update()
    {
        scoreText.text = "Score: " + _player.score.ToString();
        
    }

    public void UpdateLives(int curentLives)
    {
        livesImage.sprite = livesSprite[curentLives];
        if (curentLives==0)
        {
            _gameManager.GameOver();
            restartText.gameObject.SetActive(true);
            StartCoroutine(GameOverRoutine());
            
        }
    }

    IEnumerator GameOverRoutine()
    {
        while (true)
        {
            gameOverText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            gameOverText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f); 
        }
        
    }
    
    
    
}
