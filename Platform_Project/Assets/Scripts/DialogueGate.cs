using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueGate : MonoBehaviour
{

    //Determine specific dialogues to 'open gate'
    [SerializeField] DialogueManager trigger;
    [SerializeField] string name;


    //Destroy Gate upon end of dialogue
    private void Update()
    {
        if(trigger.dialogueEnd && (name == trigger.nameText.text.ToString()))
        {
            Destroy(gameObject);
        }
    }
}
