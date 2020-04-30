using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pac_rat_movement : MonoBehaviour
{



    public float speed;
    public bool MoveRight;

    void Update()
    {

        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            //  transform.localScale(2, 2);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            //  transform.localScale(-2, 2);
        }

    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("turn"))
        {
            if (MoveRight)
            {
                MoveRight = false;
            }

            else
            {
                MoveRight = true;
            }
        }




    }
}

    /* private bool movingLeft;
     private float MoveSpeed = 5.0f;

    public float speed;
    public float distance;

    public bool movingRight;



    private void Update()
    {

        if (transform.position.x < -21.5)
        {
            movingLeft = false;
        }

        if (transform.position.x > -13.5)
        {
            movingLeft = true;
        }

        if (movingLeft)
        {
            transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
        }



    }
}

   void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.name == "Player")
            {
                collision.GetComponent<GameSession>().ProcessDamage();
            }
        }
        */

//}
