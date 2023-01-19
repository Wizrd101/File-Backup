using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Video: https://www.youtube.com/watch?v=yyg0yV2roPk

public class ClimbingMovement : MonoBehaviour
{
    float vertical;
    float speed = 1.0f;
    bool isClimbable;
    bool isClimbing;

    public Rigidbody2D rb;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {

        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {

        }
    }
}
