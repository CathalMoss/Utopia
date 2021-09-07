using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private float runSpeed = 2.0f;
    [SerializeField] private float jumpSpeed = 2.0f;
    [SerializeField] private float climbSpeed = 2.0f;
    [SerializeField] private Vector2 deathPunch = new Vector2(25f, 25f);
    [SerializeField] private AudioClip jumpFX;
    [SerializeField] private AudioClip deathFX;
    

    private Rigidbody2D rb;
    private CapsuleCollider2D myBodyCollider;  
    private BoxCollider2D myFeetCollider;
    private Animator animator;
    float gravityScaleAtStart;

    // state of the player
    private bool IsAlive = true;    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        gravityScaleAtStart = rb.gravityScale;  
    }

    void Update()
    {
        if (IsAlive == false) return;  

        PlayerRun();
        PlayerClimb();
        PlayerJump();
        FlipSprite();   
        OutOfBounds();
        Die(); 
    }

    private void PlayerRun()
    {
        float hMovement = Input.GetAxis("Horizontal");  // change direction
        //rb.velocity = new Vector2(hMovement * speed, 0);
        // take account of the y movement
        Vector2 runVelocity = new Vector2(hMovement * runSpeed, rb.velocity.y);
        rb.velocity = runVelocity;
        // set the running animation if the player has horizontal speed
        bool playerHasHSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        animator.SetBool("IsRunning", playerHasHSpeed);   // reference by string
    }

    private void PlayerClimb()
    {
        // if not touching a ladder, then don't climb
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("ClimbObjects")))
        {
            rb.gravityScale = gravityScaleAtStart;
            animator.SetBool("IsClimbing", false);
            return;
        }
        float vMovement = Input.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(rb.velocity.x, vMovement * climbSpeed);
        rb.gravityScale = 0;
        rb.velocity = climbVelocity;
        // set off the climbing animation
        bool playerHasVSpeed = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
        animator.SetBool("IsClimbing", playerHasVSpeed);
    }

    private void PlayerJump()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Foreground")))
        {
            return;
        }
        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0, jumpSpeed);
            AudioSource.PlayClipAtPoint(jumpFX, Camera.main.transform.position);
            rb.velocity += jumpVelocityToAdd;
        }
    }

    private void FlipSprite()
    {
           bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1.0f);
        }
    }

    private void Die()
    {
        // is the player layer in contact with the enemy layer
         if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies" )))
        {
            AudioSource.PlayClipAtPoint(deathFX, Camera.main.transform.position);
            // player dies
            IsAlive = false;
            // trigger a dying animation
            animator.SetTrigger("Dying");    // reference by string
            rb.velocity = deathPunch;
            // ask the GameSession to manage a player death
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }

    }

    private void OutOfBounds()
    {
        // is the player layer in contact with the outofbounds layer
        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("OutOfBounds")))
        {
            AudioSource.PlayClipAtPoint(deathFX, Camera.main.transform.position);
            // player dies
            IsAlive = false;
            // trigger a dying animation   
            animator.SetTrigger("Dying");    // reference by string
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }

    }
}
