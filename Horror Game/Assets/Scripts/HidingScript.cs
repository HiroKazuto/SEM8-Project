using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class HidingScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Camera playerCamera;
    public Camera hidingSpotCamera;
    public GameObject playerObject;
    public enemyAI monsterScript;
    public Transform monsterTransform;
    public float loseDistance;

    bool playerHidingState = false;

    // Update is called once per frame

    void Update()
    {
        if(playerHidingState)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Pressed E");
                PlayerCameraSwitch(false);
            }
        }
        
    }


    public void TestScript()
    {
        Debug.Log("Player Hiding");
    }

    public void HideCameraSwitch(bool hideState)
    {
        playerObject.SetActive(false);
        playerCamera.enabled = false;
        hidingSpotCamera.enabled = true;
        playerHidingState = hideState;
        float distance = Vector3.Distance(monsterTransform.position, playerObject.transform.position);
        if(distance > loseDistance)
        {
            if(monsterScript.chasing == true)
             {
                monsterScript.stopChase();

              }
    }
    }

    public void PlayerCameraSwitch(bool hideState)
    {
        playerObject.SetActive(true);
        playerCamera.enabled = true;
        hidingSpotCamera.enabled = false;
        playerHidingState = hideState;
    }


    
}
