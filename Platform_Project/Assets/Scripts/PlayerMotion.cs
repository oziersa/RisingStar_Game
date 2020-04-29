﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    [Header("Motion")]
    [SerializeField] float hMove = 10f;
    [SerializeField] float vMove = 30f;
    [SerializeField] float cMove = 5f;
    [SerializeField] float fFactor = 0.1f;
    [SerializeField] float maxFallSpeed = -30f;
    [SerializeField] public bool dialogue = false;
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject startPoint;

    //Cached component variables
    Collider2D feetCollider;
    Rigidbody2D playerBody;
    float gravityScaleStart;

    //Jump modifiers
    float fallMultiplier = 4.5f;
    float lowJumpMultiplier = 2.5f;
    public bool isGrounded;
    public LayerMask ground;
    [SerializeField] bool floating = false;

    //Animation
    [SerializeField] public Animator animator;
    [SerializeField] private bool facingRight = true;
	
	
    // Start is called before the first frame update
    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<PolygonCollider2D>();
        gravityScaleStart = playerBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogue)
        {
            //Simple logic test to save coding space
            if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Foreground")))
            {
                isGrounded = true;
                playerBody.gravityScale = gravityScaleStart;

            }
            else
            {
                isGrounded = false;
            }

            //Horizontal control
            Run();

            //Vertical control
            Jump();
            JumpControl();
            LadderClimb();

        }

        //Motion of player is 0 during dialogue
        if (dialogue)
        {
            playerBody.velocity = new Vector2(0, 0);
        }
    }

    

    public void Run()
    {
		
		float hInput;
		
		
		//Input reception
		hInput = Input.GetAxis("Horizontal") * hMove;
	

        //Animation update
        animator.SetFloat("speed", Mathf.Abs(hInput));
        Flip(hInput);

        //Change in x-position
        playerBody.velocity = new Vector2(hInput, playerBody.velocity.y);
    }
 
    //Initial jumping mechanic
     public void Jump()
    {
        //Adding jumps
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerBody.velocity += new Vector2(0f, vMove);
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }
        
    }
     
    //Provide more jump control for a higher quality jump experience
    public void JumpControl()
    {
        //Shortened fall period
        if(playerBody.velocity.y < 0 && !Input.GetButtonDown("Jump"))
        {           
            playerBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            
        }

        //Floating fall
        if(playerBody.velocity.y < 0 && Input.GetButton("Jump") && floating)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, vMove * fFactor);
        }

        //Small jump
       else if (playerBody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            playerBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        //Maximum drop velocity
        if(playerBody.velocity.y < maxFallSpeed)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, maxFallSpeed);
        }
       
    }

    public void LadderClimb()
    {
        //Check for climbable material
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Climb")))
        {
            playerBody.gravityScale = gravityScaleStart;
            return;
        }

        //Determine if the player is climbing
        //Option to remove downward float
        playerBody.gravityScale = 0f;
        playerBody.velocity = new Vector2(playerBody.velocity.x, cMove * Input.GetAxisRaw("Vertical"));
        
    }

    //Player death; Reset position
    public void PlayerPerish()
    {
        gameObject.transform.position = startPoint.transform.position;
    }

    public void Flip(float horizontal)
    {
        // flips the sprite from left to right
        if (horizontal < 0 && !facingRight || horizontal > 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
