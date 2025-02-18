using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] float maxDistance = 10f;
    GameObject hitObject;
    public TMP_Text text;
    public DoorController doorController;
    void Update()
    {
        // Create a ray from the center of the screen
        text.enabled = false;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            hitObject = hit.collider.gameObject;
            if(hitObject.tag == "Interactable")
            {
                text.enabled = true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Pressed E");
                    Debug.Log(hitObject.name + " Destroyed");
                    Destroy(hitObject);
                }
            }
            if(hitObject.tag == "Door")
            {
                text.enabled = true;
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Pressed E");
                    doorController.ToggleDoor();
                }

            }
        }
        else
        {
            text.enabled = false;
        }
    }

    public GameObject GetHitObject() 
    { 
        return hitObject; // Method to return the hit GameObject
    }
}
