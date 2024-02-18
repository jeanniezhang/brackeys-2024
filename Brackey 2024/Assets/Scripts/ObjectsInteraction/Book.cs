using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Book : InteractableObject, ITalkable
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueController dialogueController;

    public bool spokenTo = false;

    public override void Interact()
    {
        spokenTo = true;
        Talk(dialogueText);
    }

    public void Talk(DialogueText dialogueText)
    {
        Debug.Log(GameManager.currentDay);
        dialogueController.DisplayNextParagraph(dialogueText);
    }
}
