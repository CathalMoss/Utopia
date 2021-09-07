using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneController : MonoBehaviour
{
    public void Back_OnClick()
    {
        //back out of options 
        FindObjectOfType<GameSession>().UnPauseGame();
        SceneManager.UnloadSceneAsync("Options");
    }
}
