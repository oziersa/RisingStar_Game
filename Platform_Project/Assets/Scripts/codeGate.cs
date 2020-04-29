using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codeGate : MonoBehaviour
{
    // correct code is private!!
    string correct_code;
	public string code_entered;
	public string color;
	public bool reset = true;
	public AudioClip success;
	public AudioClip fail;
	public AudioClip door_open;

	private void Start()
	{
		correct_code = "yellow green blue red ";
		code_entered = "";
		color = "";
	}
	
    void Update()
    {
        if(correct_code.Equals(code_entered))
        {
			AudioSource.PlayClipAtPoint(success, transform.position);
            transform.position += new Vector3(1000, 1000, 0);
			// yeet
			// sorry it gave me errors when I tried to delete it shhhh don't tell
			AudioSource.PlayClipAtPoint(door_open, transform.position);
        }
		
		if(!correct_code.Equals(code_entered) && correct_code.Length == code_entered.Length)
		{
			// the code is wrong! reset!
			AudioSource.PlayClipAtPoint(fail, transform.position);
			reset = true;
			code_entered = "";
			color = "";
		}
		
		if (!color.Equals(""))
		{
			reset = false;
			code_entered += (color + " ");
			color = "";
		}
		
    }
}