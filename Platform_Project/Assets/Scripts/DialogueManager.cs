using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    Queue<string> sentences;
    [SerializeField] public Text nameText;
    [SerializeField] Text dialogueText;
    public Animator animator;
    [SerializeField] float waitTime = 0.05f;
    [SerializeField] AudioClip blip;
    [SerializeField] public bool dialogueEnd;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if(FindObjectOfType<PlayerMotion>())
        {
            FindObjectOfType<PlayerMotion>().GetComponent<PlayerMotion>().dialogue = true;
        }

        //Clear Queue for a new dialogue
        sentences.Clear();
        dialogueEnd = false;

        animator.SetBool("IsDialogue", true);
        nameText.text = dialogue.dialogueName;

        //Add new dialogue into the Queue
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        ShowNextSentence();
    }


    public void ShowNextSentence()
    {
        Debug.Log("Next");
        //To end the dialogue
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string currentSentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeCharacters(currentSentence));
    }

    IEnumerator TypeCharacters(string sentence)
    {
        dialogueText.text = "";
        foreach(char character in sentence.ToCharArray())
        {
            dialogueText.text += character;
            AudioSource.PlayClipAtPoint(blip, transform.position);
            yield return new WaitForSecondsRealtime(waitTime);
        }
    }

    private void EndDialogue()
    {
        if (FindObjectOfType<PlayerMotion>())
        {
            FindObjectOfType<PlayerMotion>().GetComponent<PlayerMotion>().dialogue = false;
        }
        StopAllCoroutines();
        animator.SetBool("IsDialogue", false);
        dialogueEnd = true;
    }
}