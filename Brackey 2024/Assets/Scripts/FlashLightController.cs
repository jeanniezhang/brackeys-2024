using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashLightController : MonoBehaviour
{

    public float adjustmentFactor = 5.0f;
    private float scroll, timer;
    private float lastRadius = 0;
    public float delay = 0.1f;
    public float sensitivity;
    public Light2D flashLight;
    private float charge = 100f;
    public TMP_Text chargeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        lightControl();
        lightBattery();
    }

    void ProcessInputs()
    {
        scroll = Input.GetAxisRaw("Mouse ScrollWheel");
    }


    void lightControl()
    {

        if (0 <= flashLight.pointLightOuterRadius && flashLight.pointLightOuterRadius <= 10 && scroll != 0)
        {
            lastRadius = flashLight.pointLightOuterRadius;
            flashLight.pointLightOuterRadius += adjustmentFactor * scroll;
        }
        else if (scroll != 0)
        {
            flashLight.pointLightOuterRadius = lastRadius;
        }

    }

    void lightBattery()
    {
        timer += Time.deltaTime;
        if (charge > 0 && timer > delay)
        {

            charge -= Time.deltaTime * flashLight.pointLightOuterRadius * sensitivity;
            timer = 0;
            chargeText.text = "Charge: " + charge.ToString("F5");
        } else if (charge <= 0)
        {
            flashLight.intensity = 0;
            charge = 0;
        }

    }

}
