using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryManager : MonoBehaviour
{
    public Image batteryBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        reduceBatteryImage();
    }

    public void reduceBatteryImage()
    {
        batteryBar.fillAmount = FlashLightController.instance.charge / 100f;
    }
}
