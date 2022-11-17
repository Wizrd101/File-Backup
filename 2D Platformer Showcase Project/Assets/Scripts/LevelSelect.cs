using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void LevelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    public void LevelThree()
    {
        SceneManager.LoadScene("LevelThree");
    }

    public void Back()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
