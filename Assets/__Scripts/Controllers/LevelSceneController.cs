using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneController : MonoBehaviour
{
    public void Pause_OnClick()
    {
        //load pause menu
        if (Mathf.Approximately(Time.timeScale, 1f))
        {
            FindObjectOfType<GameSession>().PauseGame();
            SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
            DontDestroyOnLoad(gameObject);
        }
    }
}
