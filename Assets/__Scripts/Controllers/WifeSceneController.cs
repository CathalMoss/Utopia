using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WifeSceneController : MonoBehaviour
{
    public void Back_OnClickWife()
    {
        SceneManager.UnloadSceneAsync("Wife");
    }
}
