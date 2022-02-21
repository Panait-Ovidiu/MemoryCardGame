using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool hideMatches = false;

    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void setMatches()
    {
        if(hideMatches)
        {
            hideMatches = false;
        } else
        {
            hideMatches = true;
        }
    }

    public static bool isHideMatches()
    {
        return hideMatches;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
