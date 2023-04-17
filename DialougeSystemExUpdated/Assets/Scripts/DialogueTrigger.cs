using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script sits on an object, and will tell Dialogue to tell the DialogueManager to start a conversation

public class DialogueTrigger : MonoBehaviour
{
    public Slider switchSlider;

    // Makes this script able to access the Dialogue script and get its variables
    public Dialogue dialogue1;
    public Dialogue dialogue2;

    public Dialogue currentDialogue;

    void Start()
    {
        currentDialogue = dialogue1;
    }

    public void TriggerDialogue()
    {
        // Tells the Dialogue Manager to start talking
        FindObjectOfType<DialogueManager>().StartDialogue(currentDialogue);
    }

    public void SwitchDialogue()
    {
        if (switchSlider.value == 0 )
        {
            currentDialogue = dialogue1;
        }
        else if ( switchSlider.value == 1 )
        {
            currentDialogue = dialogue2;
        }
    }
}
