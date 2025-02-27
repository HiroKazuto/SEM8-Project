using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightControlScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
        

    public void DisableLight()
    {
        GameObject[] testLights = GameObject.FindGameObjectsWithTag("Disabled Light");
        foreach (GameObject light in testLights)
        {
            Debug.Log("Found a Disabled Light: " + light.name);
            light.SetActive(false);
        }
    }

}

    

