using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platefrom_movement : MonoBehaviour
{
    // Update is called once per frame

    private bool movingLeft;
    private float MoveSpeed = 0.5f;
    void Update()
    {
        if(transform.position.x < -4)
        {
            movingLeft = false;
        }
        
        if(transform.position.x > 4)
        {
            movingLeft = true;
        }

        if(movingLeft)
        {
            transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
        }
    }

   
}
