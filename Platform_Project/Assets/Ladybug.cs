using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladybug : MonoBehaviour
{
    private float movementSpeed = -2f;
    //Reference to script component on player object
    public PlayerMotion playerscript;

    private Rigidbody2D rbody;
    private Vector2 dirVector;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        dirVector = new Vector2(movementSpeed, 0f);
        rbody.velocity = dirVector;
    }

    private void FixedUpdate()
    {
        rbody.velocity = dirVector;
    }

    //Kill the player if it runs into them, flip if it runs into a wall
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rbody.position.y - collision.GetContact(0).point.y < 0.01f)
        {
            if (collision.gameObject.layer == 10)
            {
                playerscript.PlayerPerish();
            }
            else if (collision.gameObject.layer == 8 || collision.gameObject.layer == 15)
            {
                Flip();
            }
        }
    }

    private void Flip()
    {
        movementSpeed *= -1f;
        dirVector = new Vector2(movementSpeed, 0f);
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
