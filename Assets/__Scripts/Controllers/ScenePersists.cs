using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersists : MonoBehaviour
{
    private int startingSceneIndex = 0;
    public void Awake()
    {
        int numScenePersists = FindObjectsOfType<ScenePersists>().Length;
        if (numScenePersists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Start()
    {
        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex != startingSceneIndex)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

