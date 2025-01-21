using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    [SerializeField] float maxDistance = 10f;
    GameObject hitObject;
    public TMP_Text text;
    
    void FixedUpdate()
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

