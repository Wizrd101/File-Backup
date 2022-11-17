using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;

    public float moveSpeed = 10.0f;
    float moveX;

    public float jumpSpeed = 4.0f;
    bool grounded = false;
    public int maxDJ = 1;
    public int currentDJ = 1;

    public LayerMask groundLayer;
    public LayerMask treeLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        Vector2 velocity = rb.velocity;
        velocity.x = moveX * moveSpeed;
        rb.velocity = velocity;
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if (rb.velocity.y < -0.1f && !grounded)
        {
            anim.SetTrigger("fall");
        }
        anim.SetFloat("xInput", moveX);
        anim.SetBool("grounded", grounded);
        if (moveX < 0)
        {
            sr.flipX = false;
        }
        else if (moveX > 0)
        {
            sr.flipX = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.gravityScale = 2;
            anim.SetBool("diving", true);
        }
        else
        {
            rb.gravityScale = 1;
            anim.SetBool("diving", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground"||other.tag == "TreeBranches")
        {
            grounded = true;
            currentDJ = maxDJ;
            jumpSpeed = 4.0f;
            anim.SetBool("grounded", true);
        }
        else if (other.tag == "addDJ")
        {
            maxDJ++;
            currentDJ++;
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground"||other.tag == "TreeBranches")
        {
            grounded = false;
            anim.SetBool("grounded", false);
        }
    }

    void Jump()
    {
        if (grounded)
        {
            rb.AddForce(new Vector2(0, 100 * jumpSpeed));
            anim.SetTrigger("jump");
        }
        else if (currentDJ > 0)
        {
            if (rb.velocity.y < 0)
            {
                rb.AddForce(new Vector2(0, (-rb.velocity.y * 100) + 50 * jumpSpeed));
            }
            else
            {
                rb.AddForce(new Vector2(0, 100 * jumpSpeed));
            }
            anim.SetTrigger("jump");
            jumpSpeed -= 0.8f;
            currentDJ--;
        }
    }
}