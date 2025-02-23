using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class PauseGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    bool isPaused = false;
    public FirstPersonController firstPersonController;
    
    public GameObject pausePanel;
    
    // Update is called once per frame
    void Start()
    {
        
        firstPersonController = GetComponent<FirstPersonController>();
        pausePanel.SetActive(false);
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused)
            {
                pausePanel.SetActive(false);
                Resume();
            }
            else if(!isPaused)
            {
                pausePanel.SetActive(true);
                Pause();
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        
        firstPersonController.enabled = true;
        Cursor.visible = false;
        Debug.Log("Resume");
        isPaused = false;
        
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        
        firstPersonController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("Pause");
        Cursor.visible = true;
        isPaused = true;
        
    }
}
