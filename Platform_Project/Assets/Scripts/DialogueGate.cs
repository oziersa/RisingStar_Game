using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueGate : MonoBehaviour
{
    [SerializeField] DialogueManager trigger;

    //Destroy Gate upon end of dialogue
    private void Update()
    {
        if(trigger.dialogueEnd)
        {
            Destroy(gameObject);
        }
    }
}
