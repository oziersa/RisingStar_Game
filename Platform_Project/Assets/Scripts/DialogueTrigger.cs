using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMotion>() && Input.GetButton("Fire1"))
        {
            TriggerDialogue();
        }
    }
}
