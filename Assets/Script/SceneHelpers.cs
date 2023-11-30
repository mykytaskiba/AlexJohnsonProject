using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelpers : MonoBehaviour
{
    /// <summary>
    /// Changes the current scene to the specified scene
    /// </summary>
    /// <param name="index">Scene's index to be loaded</param>
    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    /// <summary>
    /// Changes the current scene to the specified scene
    /// </summary>
    /// <param name="sceneName">Scene's name to be loaded</param>
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    /// <summary>
    /// Call on unity's the application quit 
    /// </summary>
    public void ExitApplication()
    {
        Application.Quit();
    }
}
