using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    private Vector3 targetPosition = new Vector3(47f, 60f, 175f);
    private Quaternion targetRotation = Quaternion.Euler(2.3f, 87f, 3f);
    private Vector3 initialPosition = new Vector3(47f, 57.8f, 160f);
    private Quaternion initialRotation = Quaternion.Euler(1.5f, 93f, 0.45f);

    private float leanTimer = 4f;


    void Start()
    {
        player.transform.rotation = initialRotation;
        player.transform.position = initialPosition;
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && leanTimer > 0f)
        {
            leanTimer -= Time.deltaTime;
            player.transform.position = Vector3.Lerp(player.transform.position, targetPosition, Time.deltaTime * 5f);
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, targetRotation, Time.deltaTime * 5f);
            
            
        }
        else
        {
            
            player.transform.position = Vector3.Lerp(player.transform.position, initialPosition, Time.deltaTime * 5f);
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, initialRotation, Time.deltaTime * 5f);
            
            if(Vector3.Distance(player.transform.position, initialPosition) < 0.1f)
            {
                leanTimer = 4f;
            }

            
        }
    }
}