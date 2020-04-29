using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Springs in sonic inspired level
public class Springs : MonoBehaviour
{
    //public variable for how far up the player is pushed
    public float bounceMultiplier = 1750f;
    //private variable for finding audio source (boing sound effect)
    private AudioSource source;

    //collision checker
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            ContactPoint2D contact = collision.GetContact(0);
            Vector2 pos = contact.point;
            source = collision.gameObject.GetComponentInChildren(typeof(AudioSource)) as AudioSource;
            if (collision.collider is PolygonCollider2D && collision.rigidbody.position.y > pos.y)
            {
                if (collision.rigidbody.velocity.y < 0.05) {
                    //only bounce up if the player was moving downward and above the spring
                    Vector2 upForce = new Vector2(0f, bounceMultiplier);
                    collision.rigidbody.AddForce(upForce);
                    source.Play();
                }
            }
        }
    }
}
