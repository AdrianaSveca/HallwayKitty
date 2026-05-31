using UnityEngine;

public class LightManager : MonoBehaviour
{

    public Light[] lights; // Array of lights to manage
    public CatMovement catMovement; // Reference to the CatMovement script to check the cat's current position
    public float flickerTimer; // Timer to control the flickering effect
    public float flickerSpeed = 2f; // Speed of the flickering effect
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flickerTimer = Random.Range(0.1f, 2f); // Initialize the flicker timer with a random value between 0.1 and 0.5 seconds
    }

    // Update is called once per frame
    void Update()
    {
        if (catMovement.currentPointIndex == 2)
        {
            flickerTimer -= Time.deltaTime; 
            if (flickerTimer <= 0f)
            {
                //pick a random state
                int randomState = Random.Range(0, 2); // Randomly choose between 0 (off) and 1 (on)
                lights[1].enabled = randomState == 1; // Set the first light's state based on the random value
                flickerTimer = Random.Range(0.1f, 0.5f)/flickerSpeed; // Reset the timer with a random value between 0.1 and 0.5 seconds
            }
            
            for(int i = 2; i < lights.Length; i++)
            {
                lights[i].enabled = true; 
            }

        
        }
        else if (catMovement.currentPointIndex == 3)
        {
            flickerTimer -= Time.deltaTime;
            if (flickerTimer <= 0f)
            {
                //pick a random state
                int randomState2 = Random.Range(0, 2); // Randomly choose between 0 (off) and 1 (on)
                int randomState = Random.Range(0, 2); // Randomly choose between 0 (off) and 1 (on)
                lights[3].enabled = randomState == 1; 
                flickerTimer = Random.Range(0.1f, 0.5f)/flickerSpeed; // Reset the timer with a random value between 0.1 and 0.5 seconds
                lights[2].enabled = randomState2 == 1;
                
         
            }
            
            for(int i = 4; i < lights.Length; i++)
            {
                lights[i].enabled = true; 
            }
        }
        else if(catMovement.currentPointIndex == 4)
        {
            flickerTimer -= Time.deltaTime;
            if (flickerTimer <= 0f)
            {
                //pick a random state
                int randomState = Random.Range(0, 2); // Randomly choose between 0 (off) and 1 (on)
                int randomState2 = Random.Range(0, 2);
                lights[2].enabled = randomState2 == 1; // Set the second light's
                lights[4].enabled = randomState == 1; // Set the fourth light's state based on the random value
                flickerTimer = Random.Range(0.1f, 0.5f)/flickerSpeed; // Reset the timer with a random value between 0.1 and 0.5 seconds
            }
            
            for(int i = 2; i < lights.Length; i++)
            {
                lights[i].enabled = true; 
            }
        }
        else if(catMovement.currentPointIndex == 5)
        {
            flickerTimer -= Time.deltaTime;
            if (flickerTimer <= 0f)
            {

                int randomState = Random.Range(0, 2); // Randomly choose between 0 (off) and 1 (on)
                lights[5].enabled = randomState == 1;
                lights[6].enabled = randomState == 1; // Set the sixth light's state based on the random value
                flickerTimer = Random.Range(0.1f, 0.5f)/flickerSpeed; // Reset the timer with a random value between 0.1 and 0.5 seconds
            }
        }
    }
}
