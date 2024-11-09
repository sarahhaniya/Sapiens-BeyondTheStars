using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    //public float jumpForce = 10f;
    //public Transform groundCheck;
    //public LayerMask groundLayer;

    //private Rigidbody2D rb;
    //private bool isGrounded;

    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //}

    //private void Update()
    //{
    //    isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

    //    if (isGrounded && Input.GetKeyDown(KeyCode.Space))
    //    {
    //        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    //    }
    //}


    public float speed;
    public float jump;
    public float move;

    private Rigidbody2D rb;

    public bool isJumping;

    private void Start()
    {
       // rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        move = Input.GetAxis("Horizpntal");
        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        if (Input.GetButtonUp("Jump"))
        {

            rb.AddForce(new Vector2(rb.velocity.x, jump));

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
