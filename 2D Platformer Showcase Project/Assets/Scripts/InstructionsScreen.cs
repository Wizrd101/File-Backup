using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsScreen : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
