using UnityEngine;

public class LightManager : MonoBehaviour
{

    public Light[] lights; // Array of lights to manage
    public CatMovement catMovement; // Reference to the CatMovement script to check the cat's current position
    public float flickerTimer = 0f; // Timer to control the flickering effect
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (catMovement.currentPointIndex == 1)
        {
            flickerTimer -= Time.deltaTime; 
            if (flickerTimer <= 0f)
            {
                //pick a random state
                int randomState = Random.Range(0, 2); // Randomly choose between 0 (off) and 1 (on)
                lights[0].enabled = randomState == 1; // Set the first light's state based on the random value
                flickerTimer = Random.Range(0.1f, 0.5f); // Reset the timer with a random value between 0.1 and 0.5 seconds
            }
            lights[1].enabled = true;
            lights[2].enabled = true;
            lights[3].enabled = true;
            lights[4].enabled = true;
            lights[5].enabled = true;
            lights[6].enabled = true;
            lights[7].enabled = true;
            lights[8].enabled = true;
            lights[9].enabled = true;
        }
        else if (catMovement.currentPointIndex == 2)
        {
        }
        else if (catMovement.currentPointIndex == 3)
        {
         
        }
        
    }
}
