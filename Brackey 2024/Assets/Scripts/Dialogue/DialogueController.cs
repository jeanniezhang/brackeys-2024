using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI ObjectNameText;
    [SerializeField] private TextMeshProUGUI ObjectDialogueText;
    [SerializeField] private PlayerMovement player;

    [SerializeField] AudioSource SFXSource;
    [SerializeField] private float typeSpeed = 10f;

    AudioManager audioManager;

    //the queue is used to load all the paragraphs from the DialogueText class
    //read off each paragraph one at a time and remove them from queue afterwards
    private Queue<string> paragraphs  = new Queue<string>();

    private bool conversationEnded;
    private bool isTyping;

    private string p;

    private Coroutine typeDialogueCoroutine;

    private const string HTML_ALPHA = "<color=#00000000>";
    private const float MAX_TYPE_TIME = 0.1f;

    private void Awake () {
        // find audio manager
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
    }

    public void DisplayNextParagraph(DialogueText dialogueText)
    {
        //if nothing in the queue
        if(paragraphs.Count == 0)
        {
            if (!conversationEnded)
            {
                //starting our conversation
                StartConversation(dialogueText);
            }
            else if (conversationEnded && !isTyping)
            {
                EndConversation(dialogueText);
                return;
            }

        }

        //if something in the queue
        if(!isTyping)
        {
            // play sound
            audioManager.PlaySFX(audioManager.nextDialogue);
            p = paragraphs.Dequeue();
            typeDialogueCoroutine = StartCoroutine(TypeDialogueText(p));
        }
        else
        {
            FinishParagraphEarly();
        }
        

        //Now we have finished the conversation
        if(paragraphs.Count == 0)
        {
            conversationEnded = true;
        }

    }

    private void StartConversation(DialogueText dialogueText)
    {

        //activate image, displays textbox
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }


        //update speakers name, can simply access the parameter
        ObjectNameText.text = dialogueText.speakerName;


        //add dialogue text to queue
        for (int i = 0; i < dialogueText.paragraphs.Length; i++)
        {
            paragraphs.Enqueue(dialogueText.paragraphs[i]);
        }
        player.canMove = false;
        player.rb.velocity = new Vector2(0, 0);
    }

    private void EndConversation(DialogueText dialogueText)
    {
        //clear the queue
        paragraphs.Clear();

        //return bool to false
        conversationEnded = false;

        
        Debug.Log(dialogueText.paragraphs[0]);
        bool isDay1End = dialogueText.paragraphs[0].Equals("Goodness, look at all these treasures! Read me a story, won't you?");
        bool isDay2End = dialogueText.paragraphs[0].Equals("\"Goodness, look at all these knick-knacks! Read me a story, won't you?\"");
        bool isDay3End = dialogueText.paragraphs[0].Equals("It’s a door.");
        bool isEnd = dialogueText.paragraphs[0].Equals("Who are you?");
        if (isDay1End) {
            SceneManager.LoadScene("Black 1", LoadSceneMode.Single);
        }
        else if (isDay2End) {
            SceneManager.LoadScene("Black 2", LoadSceneMode.Single);
        }
        else if (isDay3End) {
            SceneManager.LoadScene("Black 3", LoadSceneMode.Single);
        }
        else if (isEnd) {
            SceneManager.LoadScene("EndingScene", LoadSceneMode.Single);
        }

        //deactivate gameobject
        if (gameObject.activeSelf )
        {
            gameObject.SetActive(false);
        }


        player.canMove = true;

    }

    private IEnumerator TypeDialogueText(string p)
    {
        isTyping = true;

        ObjectDialogueText.text = "";

        string originalText = p;    //this is just one of the paragraphs we dequeued from the q
        string displayedText = "";
        int alphaIndex = 0;

        //breaking paragraph into letters
        foreach(char c in p.ToCharArray())
        {
            
            alphaIndex++;
            ObjectDialogueText.text = originalText; //displays all the text at the beginning but we will just make it invisible

            displayedText = ObjectDialogueText.text.Insert(alphaIndex, HTML_ALPHA); //
            ObjectDialogueText.text = displayedText;

            yield return new WaitForSeconds(MAX_TYPE_TIME / typeSpeed);

        }

        isTyping = false;
    }


    private void FinishParagraphEarly()
    {
        //stop coroutine
        StopCoroutine(typeDialogueCoroutine);

        //finish dispalying text
        ObjectDialogueText.text = p;

        //update isTyping bool
        isTyping = false;
    }
}
