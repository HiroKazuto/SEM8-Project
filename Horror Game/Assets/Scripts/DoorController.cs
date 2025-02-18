using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator doorAnimator;
    bool isOpen = false;
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    
    public void ToggleDoor()
    {
        if(isOpen == false)
        {
            isOpen = true;
            OpenDoor();
        }
        else if(isOpen == true)
        {
            isOpen = false;
            CloseDoor();
        }
        
    }

    public void OpenDoor()
    {
        doorAnimator.SetBool("Open", true);
    }
    public void CloseDoor()
    {
        doorAnimator.SetBool("Open", false);
    }
}
