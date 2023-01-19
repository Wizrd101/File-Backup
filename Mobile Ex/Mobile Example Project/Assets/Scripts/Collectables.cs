using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collectables : MonoBehaviour
{
    int coinsCollected;

    public Text text;

    void Start()
    {
        text.text = "Coins: 0";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Collectable")
        {
            coinsCollected++;
            Destroy(other.gameObject);
            text.text = "Coins: " + coinsCollected;
            if (coinsCollected >= 5)
            {
                SceneManager.LoadScene("WinScreen");
            }
        }
    }
}
