using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    int acorns = 0;
    public Slider slider;

    void Start()
    {
        slider.maxValue = 10;
        slider.value = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Acorn")
        {
            acorns++;
            Destroy(other.gameObject);
            slider.value = acorns;
            if(acorns >= 10)
            {
                Scene scene = SceneManager.GetActiveScene();
                int nextScene = scene.buildIndex;
                nextScene++;
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
