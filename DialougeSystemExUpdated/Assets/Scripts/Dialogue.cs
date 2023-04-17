using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Feeds variables into the Dialogue Trigger so that it can individualize a conversation
// Not mentioned in the video, but I think it's because if these variables were on Dialogue trigger, they wouldn't reset.
// No Mono-Behavior, because it isn't going on an object

[System.Serializable]
//Ensures that we can edit the variables from another script
public class Dialogue
{
    // Feeds in the name of the NPC that is talking
    public string name;

    // Makes stuff in the editor look better
    [TextArea(3, 10)]
    // Actual Text the NPC says
    public string[] sentences;

}
