using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Christ1");
    }
    public void GotoStart()
    {
        SceneManager.LoadScene("Start");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
