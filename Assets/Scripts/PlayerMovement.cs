
using Random = UnityEngine.Random;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    //game object player <- the player character in the scene, used for movement and rotation
    public GameObject playerCamera;
    //game object playerCamera <- the camera attached to the player, used for shaking effect when leaning
    private Vector3 cameraBasePosition;
    //game object cameraBasePosition <- the original local position of the player camera, used to reset camera position after shaking
    private Vector3 targetPosition = new Vector3(47f, 60f, 175f);
    //players target position when leaning, used to move the player so it can see the cat
    private Quaternion targetRotation = Quaternion.Euler(2.3f, 87f, 3f);
    //players target rotation when leaning, used to rotate the player so it can see the cat
    private Vector3 initialPosition = new Vector3(47f, 57.8f, 160f);
    //self explanatory, the players initial position in the scene, used to reset player position after leaning
    private Quaternion initialRotation = Quaternion.Euler(1.5f, 93f, 0.45f);
    //self explanatory, the players initial rotation in the scene, used to reset player rotation after leaning
    public float shakeAmount = 0f;
    //the amount the camera should shake when leaning, starts at 0 and increases as the player leans more, used to create a shaking effect when leaning
    public float xRotation;
    public float yRotation;
    private Quaternion cameraBaseRotation;
    public GameObject cat;
    //game object of the cat, used to determine the direction to the cat and whether the player can see the cat or not
    private RaycastHit hit;
    //a raycast hit variable used to store the result of the raycast when checking if the player can see the cat, used to determine if the cat is visible or if there is an obstacle in the way

    private float leanTimer;
    //a timer used to determine how long the player has been leaning, used to increase the shake amount as the player leans more and to reset the lean after a certain amount of time
    public float sensitivity = 50f;

    private float xMouse;
    private float yMouse;

    private float zoomFOV;
    private float normalFOV;
    public float zoomSpeed = 5f;

    public CatMovement catMovement;

    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player.transform.rotation = initialRotation;
        player.transform.position = initialPosition;
        //player transform is set to the initial position and rotation at the start of the game, ensuring the player starts in the correct location and orientation
        cameraBasePosition = playerCamera.transform.localPosition;
        //base camera position is set to the current local position of the player camera at the start of the game, used to reset camera position after shaking
        leanTimer = Random.Range(4f, 8f);
        //lean timer has a random range between 4 and 8 seconds at the start of the game, used to create variability in how long the player can lean before resetting
        cameraBaseRotation = playerCamera.transform.localRotation;
        normalFOV = playerCamera.GetComponent<Camera>().fieldOfView;
        zoomFOV = normalFOV - 15f;
        
    }

    void Update()
    {
       
        Vector3 direction = (cat.transform.position - player.transform.position).normalized;
        //direction vector from the player to the cat, used for raycasting to check if the player can see the cat 
        Vector3 moveDirection = (catMovement.teleportPoints[catMovement.currentPointIndex].position - cat.transform.position).normalized;
        //move direction for the cat to move towards the player

        //if statement to check if the player is holding down the left mouse button and if the lean timer is greater than 0, 
        // if true the player will lean towards the target position and rotation, and the shake amount will increase as the player leans more, 
        // if false the player will return to the initial position and rotation and the shake amount will reset

        if (Input.GetMouseButton(0) && leanTimer > 0f)
        {
            leanTimer -= Time.deltaTime;
            player.transform.position = Vector3.Lerp(player.transform.position, targetPosition, Time.deltaTime * 5f);
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, targetRotation, Time.deltaTime * 5f);

            xMouse = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            yMouse = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            yRotation += yMouse;
            xRotation += xMouse;

            xRotation = Mathf.Clamp(xRotation, -10f, 10f);
            yRotation = Mathf.Clamp(yRotation, -10f, 10f);

            // Lerp camera rotation based on mouse input while leaning
            playerCamera.transform.localRotation = Quaternion.Lerp(playerCamera.transform.localRotation, cameraBaseRotation * Quaternion.Euler(-yRotation, xRotation, 0f), Time.deltaTime * 5f);


            float targetFOV;
            if (Input.GetMouseButton(1))
            {
                targetFOV = zoomFOV;
               
            }
            else
            {
               targetFOV = normalFOV;
            }
            playerCamera.GetComponent<Camera>().fieldOfView = Mathf.Lerp(playerCamera.GetComponent<Camera>().fieldOfView, targetFOV, Time.deltaTime * zoomSpeed);


            if (leanTimer < 1f)
            {
                shakeAmount = 0.1f;
            }
            else if(leanTimer < 2f)
            {
                shakeAmount = 0.05f;
                
            }
            if (shakeAmount > 0f)
            {
                Vector3 shakeOffset = new Vector3 (Random.Range(-shakeAmount, shakeAmount), 0f, 0f);
                playerCamera.transform.localPosition = cameraBasePosition + shakeOffset;
                //the player camera's local position is set to the base position plus a random shake offset, creating a shaking effect when leaning
            }
            else
            {
                playerCamera.transform.localPosition = cameraBasePosition;
                shakeAmount = 0f;
                //if the shake amount is 0 or less, the player camera's local position is reset to the base position and the shake amount is set to 0, ensuring the camera does not shake when not leaning
            }
            
        }
        else
        {
            shakeAmount = 0f;
            playerCamera.transform.localPosition = cameraBasePosition;
            player.transform.position = Vector3.Lerp(player.transform.position, initialPosition, Time.deltaTime * 5f);
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, initialRotation, Time.deltaTime * 5f);
            //if the player is not holding down the left mouse button or the lean timer is 0 or less, the player will return to the initial position and rotation, and the shake amount will reset
            
            xRotation = Mathf.Lerp(xRotation, 0f, Time.deltaTime * 5f);
            yRotation = Mathf.Lerp(yRotation, 0f, Time.deltaTime * 5f);
            
            playerCamera.transform.localRotation = cameraBaseRotation * Quaternion.Euler(-yRotation, xRotation, 0f);
            
            if(Vector3.Distance(player.transform.position, initialPosition) < 0.1f)
            {
                leanTimer = Random.Range(4f, 8f);
                //if the player is close enough to the initial position, the lean timer will reset to a random value between 4 and 8 seconds, allowing the player to lean again after returning to the initial position
            }

            
        }




        //if raycast hits an object within 400 units in the direction of the cat, it will check if the hit object is the cat, if true it will log "Cat seen!" and draw a green line from the player to the hit point,
        // if false it will log "Wall/object blocking cat." and draw a red line from the player to the hit point, and move the cat towards the player using the move direction vector, creating a mechanic where the cat 
        // will try to get closer to the player if it is blocked by an obstacle
        
        if (Physics.Raycast(player.transform.position, direction, out hit, 400f))
        {
            
            if (hit.collider.transform.parent != null && hit.collider.transform.parent.gameObject == cat)
            {
                catMovement.isSeen = true;
                Debug.Log("Cat seen!");
                Debug.DrawLine(player.transform.position, hit.point, Color.green);
            }
            else
            {
                catMovement.isSeen = false;
                Debug.Log("Wall/object blocking cat.");
                Debug.DrawLine(player.transform.position, hit.point, Color.red);

                cat.transform.position += moveDirection * Time.deltaTime * 2f;

            }
        }
    }
}
