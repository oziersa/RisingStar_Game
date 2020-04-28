using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualHints : MonoBehaviour
{
    [SerializeField] Animator anim;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMotion>())
        {
            //Trigger and animation
            anim.SetBool("Active", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMotion>())
        {
            //Trigger and animatoin
            anim.SetBool("Active", false);
        }
    }
}
