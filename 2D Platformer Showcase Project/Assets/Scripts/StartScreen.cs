using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("InstructionsScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
