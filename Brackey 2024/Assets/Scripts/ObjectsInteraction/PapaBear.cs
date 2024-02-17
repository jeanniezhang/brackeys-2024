using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PapaBear : InteractableObject, ITalkable
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
