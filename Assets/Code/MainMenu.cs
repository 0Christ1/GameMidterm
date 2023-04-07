using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("shangyu 4 new");
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
