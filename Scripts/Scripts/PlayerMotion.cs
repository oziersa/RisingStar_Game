using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    [Header("Motion")]
    [SerializeField] float hMove = 10f;
    [SerializeField] float vMove = 30f;

    Rigidbody2D playerBody;
    float fallMultiplier = 4.5f;
    float lowJumpMultiplier = 2.5f;

    // Start is called before the first frame update
    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        JumpControl();
               
    }

    

    public void Run()
    {
        //Input reception
        float hInput = Input.GetAxis("Horizontal") * hMove;

        //Change in x-position
        playerBody.velocity = new Vector2(hInput, playerBody.velocity.y);
        Debug.Log(playerBody.velocity);
    }
 
    //Initial jumping mechanic
     public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            playerBody.velocity += new Vector2(0f, vMove);
        }
    }
     
    //Provide more jump control for a higher quality jump experience
    public void JumpControl()
    {
        if(playerBody.velocity.y < 0)
        {
            playerBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
       else if (playerBody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            playerBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
