using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;  
public class GameSession : MonoBehaviour
{
    // == private variables ==
    [SerializeField] private int playerLives = 10;
    [SerializeField] private int playerCoins = 0;
    [SerializeField] private int playerScore = 0;
    [SerializeField] private TextMeshProUGUI coinCountText;
    [SerializeField] private TextMeshProUGUI playerLivesText;
    [SerializeField] private TextMeshProUGUI scoreCountText;

    private void Awake()
    {
        int numberOfGameSessionObjects = FindObjectsOfType<GameSession>().Length;
        if (numberOfGameSessionObjects > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    //add methods for pause and unpause the game
    public void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    private void Start()
    {
        //display lives and coins to screen
        playerLivesText.text = playerLives.ToString();    
        coinCountText.text = playerCoins.ToString();
        Debug.Log("Start Method - Coins: " + playerCoins.ToString() + " Lives: " + playerLives.ToString());
    }

     public void AddCoins(int coinsToAdd)
    {
        playerCoins += coinsToAdd;
        //update
        coinCountText.text = playerCoins.ToString();

        // if player has 15 coins then add live
        if (playerCoins == 15)
        {
            playerLives++;
            playerLivesText.text = playerLives.ToString();
        }
    }

    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreCountText.text = playerScore.ToString();
        // if player has 1500 add live
        if (playerScore == 1500)
        {
            playerLives++;
            playerLivesText.text = playerLives.ToString();
        }
    }

   
    public void ProcessPlayerDeath()
    {
      if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        playerLives--;
        Debug.Log("TakeLife - lives left = " + playerLives.ToString());
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        playerLivesText.text = playerLives.ToString();   
    }

    private void ResetGameSession()
    {
        Debug.Log("Reset Game Session");
        SceneManager.LoadScene("IntroLevel");
        Destroy(gameObject);
    }
}
