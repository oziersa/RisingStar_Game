using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
	Rigidbody2D playerBody;
	float dash_amount = .2f;
	public Vector3 direction;
	float dash_time = 1f;
	public float curr_time;
	public float start_time;
	float cool_down = 1f;
	public bool is_dashing = false;
	public AudioClip dash_sound;
	public bool sound_played = false;
	
	private void Awake()
    {
		playerBody = GetComponent<Rigidbody2D>();
    }
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift) && !is_dashing)
		{
			is_dashing = true;
			start_time = Time.time;
			sound_played = false;
		}
			
		if (is_dashing)
		{
			curr_time = Time.time - start_time;
			
			if(curr_time < dash_time)
			{
				// want to dash in one second...
				// but make it smoooooth...
				
				float direction = 0f;
				
				if(Input.GetAxis("Horizontal") > 0)
				{
					direction = 1f;
				}
				else if(Input.GetAxis("Horizontal") < 0)
				{
					direction = -1f;
				}
				
				Vector3 vec = Vector3.right * direction * dash_amount;
				
				transform.position += vec;
				
				if (!sound_played)
				{
					AudioSource.PlayClipAtPoint(dash_sound, transform.position);
					sound_played = true;
				}
				
				
			}
			
			else if (curr_time >= dash_time && curr_time < cool_down)
			{
				// basically just wait...
				is_dashing = true;
			}
			
			else
			{
				sound_played = false;
				curr_time = 0f;
				is_dashing = false;
			}
			
		}
		
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			is_dashing = false;
		}
			
	}
	
}
	