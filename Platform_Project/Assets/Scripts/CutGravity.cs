using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutGravity : MonoBehaviour
{
    [SerializeField] float gravityFactor = 1.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMotion>())
        {
            Debug.Log("Enter");
            Physics2D.gravity =  Physics2D.gravity / gravityFactor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMotion>())
        {
            Physics2D.gravity = gravityFactor * Physics2D.gravity;
        }
    }
}
