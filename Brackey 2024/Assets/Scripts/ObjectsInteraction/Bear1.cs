using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bear1 : InteractableObject, ITalkable
{

    [SerializeField] private DialogueText dialogueText_Day_One_Start;
    [SerializeField] private DialogueText dialogueText_Day_One_End;
    [SerializeField] private DialogueController dialogueController;

    public bool Day_one_end = false;    //need to activate this to true somewhere in the day, maybe after person changes rooms

    
    public override void Interact()
    {
        if (!Day_one_end)
        {
            Talk(dialogueText_Day_One_Start);
        }
        else
        {
            Talk(dialogueText_Day_One_End);
        }
        
    }

    public void Talk(DialogueText dialogueText)
    {
        Debug.Log(GameManager.currentDay);
        dialogueController.DisplayNextParagraph(dialogueText);
        
    }
}
