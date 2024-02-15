using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ObjectNameText;
    [SerializeField] private TextMeshProUGUI ObjectDialogueText;

    //the queue is used to load all the paragraphs from the DialogueText class
    //read off each paragraph one at a time and remove them from queue afterwards
    private Queue<string> paragraphs  = new Queue<string>();

    private bool conversationEnded;

    public void DisplayNextParagraph(DialogueText dialogueText)
    {
        //if nothing in the queue
        if(paragraphs.Count == 0)
        {
            if (!conversationEnded)
            {
                //starting our conversation
                StartConversation();
            }
            else
            {
                EndConversation();
            }

        }

        //if something in the queue
    }

    private void StartConversation()
    {

    }

    private void EndConversation()
    {

    }
}
