using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingFlower : InteractableObject
{   
    AudioManager audioManager;
    private void Awake () {
        // find audio manager
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public override void Interact()
    {
        // trigger cutscene
        audioManager.StopBackground();
        audioManager.PlaySFX(audioManager.suddenSound);
    }
}
