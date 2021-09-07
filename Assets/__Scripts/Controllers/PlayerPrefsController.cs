using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    private const string MUTE_KEY = "Mute";
    
     private void Awake()
    {
        int numberOfPlayerPrefsObjects = FindObjectsOfType<PlayerPrefsController>().Length;
        if (numberOfPlayerPrefsObjects > 1)
        {
            // already have one, destroy this one
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Mute()
    {
        //mtue the sounds - name/value pair
        PlayerPrefs.SetInt(MUTE_KEY, 1);
        UpdateVolume();
    }

    public void UnMute()
    {
        PlayerPrefs.SetInt(MUTE_KEY, 0);
        UpdateVolume();
    }

    private void UpdateVolume()
    {
        if(IsMute())
        {
            AudioListener.volume = 0f;
        }
        else
        {
            AudioListener.volume = 1f;
        }
    }

    private bool IsMute()
    {
        return PlayerPrefs.GetInt(MUTE_KEY, 0) == 1;
    }
}
