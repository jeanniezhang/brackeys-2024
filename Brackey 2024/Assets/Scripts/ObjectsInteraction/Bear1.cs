using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear1 : InteractableObject, ITalkable
{

    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueController dialogueController;

    
    public override void Interact()
    {
        Talk(dialogueText);
    }

    public void Talk(DialogueText dialogueText)
    {
        Debug.Log(GameManager.currentDay);
        dialogueController.DisplayNextParagraph(dialogueText);
    }
}
