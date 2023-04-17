using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Because I'm not making a README for an example, this is the video link: https://www.youtube.com/watch?v=_nRzoTzeyxU
// Where the real brains is. This script updates everything, and takes inputs from DialogueTrigger, and plays the DialogueBox anims (In and Out)

public class DialogueManager : MonoBehaviour
{
    // Declaring the text areas for displaying the text
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    // Animator for the In and Out anims
    public Animator anim;

    /* Queue Information:
       1. Works a bit like a list, but a little different
       2. FIFO: First In, First Out*/
    private Queue<string> sentences;
    
    void Start()
    {
        // Takes the sentences from the inspector and puts them into the queue
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        // Sets the Animator bool to true, telling the animator to play the in anim
        anim.SetBool("IsOpen", true);

        // Displays the name of the NPC player is talking to
        nameText.text = dialogue.name;

        // Clears the last sentence
        sentences.Clear();

        // Gets the correct sentence to display
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }
        
        DisplayNextSentence();
    }

    // Function for displaying the sentence
    public void DisplayNextSentence()
    {
        // If there is no more text to display, skip the rest of the routine and call EndDialogue
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        // Takes the sentence currently being displayed out of queue so it doesn't get displayed again
        string sentence = sentences.Dequeue();

        // Displays the text that the NPC says immediately
        // If enabled, comment out the two lines of code below.
        /*dialogueText.text = sentence;*/

        // Displays the text that the NPC says letter-by-letter
        // If enabled, comment out the line of code above
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    // Coroutine for displaying the letters one by one
    IEnumerator TypeSentence (string sentence)
    {
        // Sets the text box to empty
        dialogueText.text = "";

        // Finds the next character, adds it to the current text, then waits a frame
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    // Function for ending dialogue when the conversation is over
    void EndDialogue()
    {
        // Sets the Animator bool to false, telling the animator to play the out anim
        anim.SetBool("IsOpen", false);
    }
}
