using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    [SerializeField] private FlashLightController flashLight;

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

            Destroy(gameObject);
        }
    }
}
