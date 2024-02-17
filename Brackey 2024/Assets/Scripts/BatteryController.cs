using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    [SerializeField] private FlashLightController flashLight;
    AudioManager audioManager;

    private void Awake () {
        // find audio manager
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            if (flashLight.charge < 75f)
            {
                flashLight.charge += 25f;
            }
            else
            {
                flashLight.charge = 100f;
            }
            flashLight.chargeText.text = "Charge: " + flashLight.charge.ToString("F0") + "%";

            audioManager.PlaySFX(audioManager.collectBattery);
            Destroy(gameObject);
        }
    }
}
