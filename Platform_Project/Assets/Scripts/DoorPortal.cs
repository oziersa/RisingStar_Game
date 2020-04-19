using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPortal : MonoBehaviour
{
    //Serialized Assets
    [SerializeField] GameObject doorChange;
    [SerializeField] GameObject player;
    [SerializeField] int chargeTime = 0;

    //Trigger Teleport Player
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMotion>() && Input.GetButton("Fire1"))
        {
            //Hold-down time
            chargeTime++;
            if(chargeTime >= 50)
            {
                player.transform.position = new Vector3(doorChange.transform.position.x, doorChange.transform.position.y, 0);
            }
        }

        else
        {
            chargeTime = 0;
        }
    }
}
