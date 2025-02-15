using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class FootstepScript : MonoBehaviour
{
    public GameObject footstep;
    public GameObject sprint;
    public FirstPersonController firstPersonController;
    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);
        sprint.SetActive(false);
    }

    // Update is called once per frame
    void Update()

    {

        if(firstPersonController._speed > 0.1f || firstPersonController._speed < -0.1f)
            if(firstPersonController._speed > 4f || firstPersonController._speed < -4f)
            {
                StopFootsteps();
                Sprint();
            }
            else
            {
                StopSprint();
                footsteps();
            }

        else

        {
            StopFootsteps();
            StopSprint();
        }

    }

    void footsteps()
    {
        footstep.SetActive(true);
    }

    void StopFootsteps()
    {
        footstep.SetActive(false);
    }

    void Sprint()
    {
        sprint.SetActive(true);
    }

    void StopSprint()
    {
        sprint.SetActive(false);
    }
}