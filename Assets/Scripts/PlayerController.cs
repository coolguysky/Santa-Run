using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    [SerializeField] float jumpForce;

    bool grounded;
    bool gameOver = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && grounded && !gameOver)
        {
            Jump();
        }
    }

    void Jump()
    {
        grounded = false;
        rb.velocity = Vector2.up * jumpForce;
        anim.SetTrigger("Jump");
        GameManager.instance.IncrementScore();
    }

    private void OnCollisionEnter2D(Collision2D collision) // not a trigger
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // is a trigger
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
            GameManager.instance.GameOver();
            gameOver = true;
            anim.Play("SantaDeath");
        }
    }
}
