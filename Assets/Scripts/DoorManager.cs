using UnityEngine;

public class DoorManager : MonoBehaviour
{
   
   public Transform doorHinge;
    public CatMovement catMovement; // Reference to the CatMovement script to check the cat's current position
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (catMovement.currentPointIndex == 3)
        {
            doorHinge.transform.localRotation = Quaternion.Lerp(doorHinge.transform.localRotation, Quaternion.Euler(0, 40, 0), Time.deltaTime * 2f); // Smoothly rotate the door to open
        }
        else
        {
            doorHinge.transform.localRotation = Quaternion.Lerp(doorHinge.transform.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 2f); // Smoothly rotate the door to close
        }
        
    }
}
