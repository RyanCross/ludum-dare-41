using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue goodEndingDialogue;
    public Dialogue badEndingDialogue;
    private bool isPrincessImpressed;
    public int playerSexyPoints;

     void Awake()
    {
       //retrieve this from player inventory instead of setting it in the insepctor
    }

    public void TriggerDialogue()
    {
        Dialogue actualDialogue;

        if (playerSexyPoints >= 2)
        {
            isPrincessImpressed = true;
            actualDialogue = goodEndingDialogue;
        }
        else
        {
            isPrincessImpressed = false;
            actualDialogue = badEndingDialogue;
        }
        FindObjectOfType<DialogueManager>().StartDialogue(actualDialogue, isPrincessImpressed);
    }

}
