using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingFlower : InteractableObject, ITalkable
{   
    AudioManager audioManager;

    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueController dialogueController;
    private void Awake () {
        // find audio manager
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public override void Interact()
    {
        // trigger cutscene

        audioManager.StopBackground();
        // audioManager.PlaySFX(audioManager.suddenSound);
        // audioManager.PlaySFX(audioManager.sad);
    
        Talk(dialogueText);
    }

    public void Talk(DialogueText dialogueText)
    {
        dialogueController.DisplayNextParagraph(dialogueText);
    }
}
