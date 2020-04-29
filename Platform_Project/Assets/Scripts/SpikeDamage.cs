using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{

	// when player touches spike,
	// they should die and go back to last checkpoint
	// the same as if they touched an enemy. 
	
	private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMotion>())
        {
            PlayerMotion player = collision.GetComponent<PlayerMotion>();
            player.PlayerPerish();
            Debug.Log("oof");
        }
    }

}