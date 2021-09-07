using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsSceneController : MonoBehaviour
{
    public void Back_OnClick()
    {
        SceneManager.UnloadSceneAsync("Options");
    }

    public void MuteOnValueChanged(bool muteValue)
    {
        if(muteValue == true)
        {
            if(muteValue == true)
            {
                FindObjectOfType<PlayerPrefsController>().Mute();
            }
            else
            {
                FindObjectOfType<PlayerPrefsController>().UnMute();
            }
        }
 
    }

    public void Back_OnClickControls()
    {
        // back out of controls
        FindObjectOfType<GameSession>().UnPauseGame();
        SceneManager.UnloadSceneAsync("Controls");
    }
}
