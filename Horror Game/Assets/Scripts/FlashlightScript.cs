using System;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlashlightScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public Light flashlight;
   public GameObject sfx;
   private bool isOn = false;
    void Start()
    {
        sfx.SetActive(false);
    }
    void Update() 
   { 
        if (Input.GetKeyDown(KeyCode.F)) 
        { 
           isOn = !isOn;
           flashlight.enabled = isOn;
           if(isOn == true)
           {
            sfx.SetActive(true);
           }
           else
           {
            sfx.SetActive(false);
           }
        } 
    }
}


