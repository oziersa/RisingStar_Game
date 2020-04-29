using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codeButtonPress : MonoBehaviour
{
    [SerializeField] bool touched = false;
	[SerializeField] public string color;
	
	[SerializeField] public Sprite button_pressed;
	[SerializeField] public Sprite not_pressed;
	// save current sprite
	
	[SerializeField] public AudioClip button_push;
	float time_touch = 0f;
	
	void Update()
	{
		if (FindObjectOfType<codeGate>().reset && touched)
			{
				// want to give it a half second before it restarts
				// or else it might just press down again and that's no good
				float time_passed = Time.time - time_touch;
				if (time_passed >= 0.2f)
				{
					reset();
				}
			}
			
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!touched && Input.GetButton("Fire1"))
        {
			
            touched = true;
			time_touch = Time.time;
            // once it's touched, send color...
			FindObjectOfType<codeGate>().color = color;
			// ... and update the sprite
			GetComponent<SpriteRenderer>().sprite = button_pressed;
			// and play the button push sound!!
			AudioSource.PlayClipAtPoint(button_push, transform.position);
        }
    }
	
	private void reset()
	{
		touched = false;
		GetComponent<SpriteRenderer>().sprite = not_pressed;
		
	}
}