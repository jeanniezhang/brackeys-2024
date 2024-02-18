using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] string SceneName;

    public AudioClip background;
    public AudioClip endingBackground;
    public AudioClip nextDialogue;
    public AudioClip moveCharacter;
    public AudioClip collectBattery;
    public AudioClip disonnantPiano;
    public AudioClip suddenSound;
    

    private void Start() {
        if (SceneName != "Ending") {
            musicSource.clip = background;
        }
        else {
            musicSource.clip = endingBackground;
        }
        
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopBackground() {
        musicSource.Pause();
    }

    public void PlaySFX(AudioClip clip) {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayWalk(AudioClip clip) {
         SFXSource.PlayOneShot(clip);
    }
}
