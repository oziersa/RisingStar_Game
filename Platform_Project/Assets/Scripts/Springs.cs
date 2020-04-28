using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Springs : MonoBehaviour
{
    public float bounceMultiplier = 1750f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Debug.Log("correct layer");
            ContactPoint2D contact = collision.GetContact(0);
            Vector2 pos = contact.point;
            if (collision.collider is PolygonCollider2D && collision.rigidbody.position.y > pos.y)
            {
                Debug.Log("above spring");
                Vector2 upForce = new Vector2(0f, bounceMultiplier);
                collision.rigidbody.AddForce(upForce);
            }
        }
    }
}
