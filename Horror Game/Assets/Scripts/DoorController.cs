using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator animator;
    bool isOpen = false;
    void Start()
    {
        animator = GetComponent<Animator>();
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
        animator.SetBool("Open", true);
    }
    public void CloseDoor()
    {
        animator.SetBool("Open", false);
    }
}
