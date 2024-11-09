using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private SpriteRenderer spriteRender;


    private Rigidbody2D body;
    private BoxCollider2D boxCollider;

    private float horizontalInput;
    public int switchOrder;
    public int fruitCollected;
    public String spriteName;
    public float trampolineJumpForce; // Add trampoline jump force here


   // public event Action PlayerDied;

    public void Awake()        //Whenever the scipt is called on run this function
    {       
        body = GetComponent<Rigidbody2D>();     //This gets the body from the compeonet that owns the script
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        switchOrder = 0;
        PlayerPrefs.SetInt("fruitCollected", 0);
        fruitCollected = 0;
    }

    public void OnEnable()
    {
        fruitCollected = PlayerPrefs.GetInt("fruitCollected");
        this.spriteName = PlayerPrefs.GetString("charName");
        String callSprite = "Characters/" + spriteName+"/"+ spriteName;
        Sprite sprite = Resources.Load<Sprite>(callSprite);
        spriteRender.sprite = sprite;
        String name = spriteRender.sprite.name;
    }

    // Update is called once per frame
    public void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed,body.velocity.y);

        //This starts the jump mechanic

        if (Input.GetKey(KeyCode.UpArrow) && isGrounded())      //If the player presses the up arrow, and they are on the ground
        {
            Jump();     //Call the jump method
        }


        //This is for flipping the player model when moving left and right
        
        if (horizontalInput > 0.01f)      //If player is moving right
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1);     //Set the player model to face right
        }
        else if (horizontalInput < -0.01f)       //If player is moving left
        {
            transform.localScale = new Vector3(-0.5f, 0.5f,1);     //Set player model to face left
        }


        if (isOnTrampoline()) // Check if the player is on a trampoline
        {
            body.velocity = new Vector2(body.velocity.x, trampolineJumpForce); // Apply the trampoline jump force
        }


    }



    private void Jump()
    {
        //This is the jump command

        body.velocity = new Vector2(body.velocity.x, speed);        //Move the player with current left and right speed, along with new upwared momentum


    }

    private void TrampolineJump()
    {
        if (isOnTrampoline()) // Check if the player is on a trampoline
        {
            body.velocity = new Vector2(body.velocity.x, trampolineJumpForce); // Apply the trampoline jump force
        }
    }

    private bool isOnTrampoline()
    {
        // Check if the player is on a trampoline based on collider checks
        Collider2D[] colliders = Physics2D.OverlapBoxAll(boxCollider.bounds.center, boxCollider.bounds.size, 0f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Trampoline"))
            {
                return true; // Player is on a trampoline
            }
        }

        return false; // Player is not on a trampoline
    }

    private bool isGrounded()
    {
        //This checks if the player box is touching any part of items tagged as ground
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down,0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded();
    }

    public void saveInfo()
    {
        PlayerPrefs.SetInt("fruitCollected", fruitCollected);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Raindrop"))
        {
           // PlayerDied.Invoke();
           // Destroy(this.gameObject);
        }

    }
}
