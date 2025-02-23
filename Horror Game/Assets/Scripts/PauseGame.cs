using System;
using UnityEngine;
using UnityEngine.AI;

public class PauseGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused)
            {
                Resume();
            }
            else if(!isPaused)
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        Debug.Log("Resume");
        isPaused = false;
        
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        Debug.Log("Pause");
        isPaused = true;
        
    }
}
