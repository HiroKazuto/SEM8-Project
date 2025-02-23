using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] float maxDistance = 10f;
    GameObject hitObject;
    public TextMeshProUGUI cursorText;
    public TextMeshProUGUI noteText;
    public Image noteImage;
    bool noteEnabled = false;
    public PauseGame pauseGame;

    void Start()
    {
        cursorText.enabled = false;
        noteImage.enabled = false;
        noteText.enabled = false;
    }
    void Update()
    {
        // Create a ray from the center of the screen
        
        
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            hitObject = hit.collider.gameObject;
            if(hitObject.tag == "Interactable")
            {
                cursorText.enabled = true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Pressed E");
                    Debug.Log(hitObject.name + " Destroyed");
                    Destroy(hitObject);
                }
            }
            if(hitObject.tag == "Door")
            {
                cursorText.enabled = true;
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Toggle Door");
                    DoorController doorController = hitObject.GetComponent<DoorController>();
                    doorController.ToggleDoor();
                }

            }
            if(hitObject.tag == "Note")
            {
                NoteScript noteScript = hitObject.GetComponent<NoteScript>();
                noteScript.AssignText();
                cursorText.enabled = true;
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(!noteEnabled)
                    {
                        noteEnabled = true;
                        noteImage.enabled = true;
                        noteText.enabled = true;
                        pauseGame.Pause();
                    }
                    else if(noteEnabled)
                    {
                        noteEnabled = false;
                        noteImage.enabled = false;
                        noteText.enabled = false;
                        pauseGame.Resume();
                    }
                        
                }

            }
        }
        else
        {
            cursorText.enabled = false;
        }
    }

    public GameObject GetHitObject() 
    { 
        return hitObject; // Method to return the hit GameObject
    }
}
