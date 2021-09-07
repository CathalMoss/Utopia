using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
      public void Start_OnClick()
    {
        SceneManager.LoadScene("Level1");  
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //collision used for next level
        GameObject collisionGameObject = collision.gameObject;
        if(collisionGameObject.name == "Player")
        {
            var index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index + 1);
        }
    }

    public void LoadIntroLevel()
    {
        SceneManager.LoadScene("IntroLevel");
    }

    public void LoadNextScene()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
       }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Options_OnClick()
    {
        //load options
         SceneManager.LoadSceneAsync("Options", LoadSceneMode.Additive);
    }

    public void Controls_OnClick()
    {
        //load controls.
        SceneManager.LoadSceneAsync("Controls", LoadSceneMode.Additive);
    }

    public void TheStory()
    {
        //load story
        SceneManager.LoadScene("TheStory");
    }

    public void Wife_OnClick()
    {
        //load wifes note
        SceneManager.LoadSceneAsync("Wife", LoadSceneMode.Additive);
    }

}
