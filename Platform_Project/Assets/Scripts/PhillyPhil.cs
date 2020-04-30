using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhillyPhil : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMotion>())
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            Destroy(gameObject.GetComponent<PhillyPhil>());
        }
    }
}
