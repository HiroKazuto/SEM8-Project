using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] float maxDistance = 10f;
    GameObject hitObject;
    public GameObject keyItem;
    public CutscenePlayerScript cutscenePlayerScript1;
    public CutscenePlayerScript cutscenePlayerScript2;
    public LightControlScript lightControlScript;
    public TextMeshProUGUI cursorText;
    public TextMeshProUGUI noteEscapeText;
    public TextMeshProUGUI noteText;
    public TextMeshProUGUI dialougeBoxText;

    
    public Image noteImage;
    bool noteEnabled = false;
    bool CutsceneDoorOpen = false;
    public PauseGame pauseGame;
    int cutSceneNoteCount = 0;
    

    void Start()
    {
        cursorText.enabled = false;
        noteImage.enabled = false;
        noteText.enabled = false;
        noteEscapeText.enabled = false;
        dialougeBoxText.enabled = false;
        keyItem.SetActive(false);
        
    }
    void Update()
    {
        // Create a ray from the center of the screen
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        
        //CutSceneDoorOpenCount
        if(cutSceneNoteCount >= 3)
        {
            CutsceneDoorOpen = true;
        }
        

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
           
            hitObject = hit.collider.gameObject;
            DoorController doorController = hitObject.GetComponent<DoorController>();


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

            if(hitObject.tag == "Hiding Spot")
            {
                cursorText.enabled = true;
                HidingScript hideCamera = hitObject.GetComponent<HidingScript>();
                if(Input.GetKeyDown(KeyCode.E))
                {
                    hideCamera.HideCameraSwitch(true);
                }
                
            }

            if(hitObject.tag == "Door")
            {
                cursorText.enabled = true;
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Toggle Door");
                    
                    doorController.ToggleDoor();
                }
            }

            if(hitObject.tag == "CutsceneDoor")
            {
                DialougeScript dialougeScript = hitObject.GetComponent<DialougeScript>();
                
                dialougeScript.AssignText();

                cursorText.enabled = true;
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    
                    if(!CutsceneDoorOpen)
                    {
                        dialougeBoxText.enabled = true;
                    }
                    else{
                        Debug.Log("Toggle Door");
                        doorController.ToggleDoor();
                        cutscenePlayerScript1.PlayCutscene();

                    }
                    
                }
            }

            if(hitObject.tag == "CutSceneMirror")
            {
                
                cursorText.enabled = true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    lightControlScript.DisableLight();
                    cutscenePlayerScript2.PlayCutscene();   
                }
            }

            if(hitObject.tag == "Key")
            {
                cursorText.enabled = true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    keyItem.SetActive(true);
                    Destroy(hitObject);
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
                        NoteObjectEnable(noteEnabled);
                        pauseGame.Pause();
                    }
                    else if(noteEnabled)
                    {
                        noteEnabled = false;
                        NoteObjectEnable(noteEnabled);
                        pauseGame.Resume();
                    }
                }
            }
        
            if(hitObject.tag == "CutsceneNotes")
            {
                NoteScript noteScript = hitObject.GetComponent<NoteScript>();
                noteScript.AssignText();
                cursorText.enabled = true;
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(!noteEnabled)
                    {
                        cutSceneNoteCount++;
                        Debug.Log("Note Count:"+cutSceneNoteCount);
                        noteEnabled = true;
                        NoteObjectEnable(noteEnabled);
                        pauseGame.Pause();
                    }
                    else if(noteEnabled)
                    {
                        noteEnabled = false;
                        NoteObjectEnable(noteEnabled);
                        pauseGame.Resume();
                    }
                }
            }
            
        }

        else
        {
            cursorText.enabled = false;
            dialougeBoxText.enabled = false;
        }
    }

    public void NoteObjectEnable(bool noteEnabled)
    {
        noteImage.enabled = noteEnabled;
        noteText.enabled = noteEnabled;
        noteEscapeText.enabled = noteEnabled;
    }

    public GameObject GetHitObject() 
    { 
        return hitObject; // Method to return the hit GameObject
    }
}
