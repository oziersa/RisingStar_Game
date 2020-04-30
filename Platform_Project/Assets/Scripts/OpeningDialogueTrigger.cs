using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDialogueTrigger : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;
    private bool first = true;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMotion>() && Input.GetButton("Fire1") && first)
        {
            TriggerDialogue();
            first = false;
        }

        else if (collision.GetComponent<PlayerMotion>() && Input.GetButton("Fire1"))
        {
            FindObjectOfType<DialogueManager>().ShowNextSentence();
        }
    }
}
