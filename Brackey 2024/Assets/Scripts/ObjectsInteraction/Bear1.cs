using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Bear1 : InteractableObject, ITalkable
{

    [SerializeField] private DialogueText dialogueText_Day_One_Start;
    [SerializeField] private DialogueText dialogueText_Day_One_End;
    [SerializeField] private DialogueController dialogueController;

    public int day;

    // public bool hasTalkedToMamaBear = false;
   
    // public bool hasRetrievedBook = false;

    
    public override void Interact()
    {
        GameObject papaBear = GameObject.FindGameObjectWithTag("PapaBear");
        bool hasTalkedToPapaBear = papaBear.GetComponent<PapaBear>().spokenTo;
        Debug.Log("Papa: " + hasTalkedToPapaBear);

        GameObject mamaBear = GameObject.FindGameObjectWithTag("MamaBear");
        bool hasTalkedToMamaBear = mamaBear.GetComponent<MamaBear>().spokenTo;
        Debug.Log("Mama: " + hasTalkedToMamaBear);

        GameObject book = GameObject.FindGameObjectWithTag("Book");
        bool hasRetrievedBook = book.GetComponent<Book>().spokenTo;
        Debug.Log("Book: " + hasRetrievedBook);
        

        if (hasTalkedToPapaBear && hasTalkedToMamaBear && hasRetrievedBook) {
            Talk(dialogueText_Day_One_End);
        }
        else 
        {
            //  Talk(dialogueText_Day_One_End);
            Talk(dialogueText_Day_One_Start);
            
        }
        
    }

    public void Talk(DialogueText dialogueText)
    {
        dialogueController.DisplayNextParagraph(dialogueText);
        
    }
}
