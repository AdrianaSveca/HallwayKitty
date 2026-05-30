using UnityEngine;

public class CatMovement : MonoBehaviour
{

    public Transform[] teleportPoints; // Array of teleport points for the cat to move between

    public bool isSeen;
    private int currentPointIndex = 0;
    private float teleportTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        teleportTimer = Random.Range(4f, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSeen)
        {
            Debug.Log("Cat is seen, DONT MOVE!");
            // Teleport cat to place in array in a random range of 4-5 seconds
        }
        else if(!isSeen)
        {
            Debug.Log("Cat is not seen, so teleport");
            //reset timer for teleporting cat to a random range of 4-5 seconds
            
            if (teleportTimer<=0f)
            {
                transform.position = teleportPoints[currentPointIndex].position;
                Debug.Log("Teleport to: " + teleportPoints[currentPointIndex].position);
                currentPointIndex++;
                if (currentPointIndex >= teleportPoints.Length)
                {
                    currentPointIndex = 0;
                }
                teleportTimer = Random.Range(4f, 8f);
                
            }
            else
            {
                teleportTimer -= Time.deltaTime;
            }
            



        }
        
    }
}
