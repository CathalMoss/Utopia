using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSceneController : MonoBehaviour
{
  
    public void Back_OnClick()
    {
        //un pause game method in gameSession
        FindObjectOfType<GameSession>().UnPauseGame();
        SceneManager.UnloadSceneAsync("PauseMenu");
    }
    public void OpenMainMenu()
    {
        FindObjectOfType<GameSession>().UnPauseGame();
        SceneManager.LoadScene("MainMenu");
    }


    public void RestartGame()
    {
        //will always revert to the intro level
        FindObjectOfType<GameSession>().UnPauseGame();
        SceneManager.LoadScene("IntroLevel");
    }
}
