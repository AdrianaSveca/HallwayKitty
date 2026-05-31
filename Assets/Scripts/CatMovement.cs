using UnityEngine;

public class CatMovement : MonoBehaviour
{

    [SerializeField] public Transform[] teleportPoints; // Array of teleport points for the cat to move between

    public bool isSeen;
    public int currentPointIndex = 0;
    private float teleportTimer;

    private float gameTimer = 999f; // Timer for the entire game, set to 60 seconds
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private bool gameEnded = false;
    void Start()
    {
        teleportTimer = Random.Range(4f, 8f);
    }

    // Update is called once per frame
    void Update()
{
    if (gameEnded)
    {
        return;
    }

    gameTimer -= Time.deltaTime;

    if (isSeen)
    {
        
    }
    else
    {

        if (teleportTimer <= 0f)
        {
            if (currentPointIndex < teleportPoints.Length)
            {
                transform.position = teleportPoints[currentPointIndex].position;


                switch (currentPointIndex)
                {
                    case 0:
                        Debug.Log("Teleporting to point 1");
                        transform.localScale += new Vector3(1f, 1f, 1f);
                        break;

                    case 1:
                        Debug.Log("Teleporting to point 2");
                        transform.localScale += new Vector3(1f, 1f, 1f);
                        break;

                    case 2:
                        Debug.Log("Teleporting to point 3");
                        transform.localScale += new Vector3(1f, 1f, 1f);
                        break;

                    case 3:
                        Debug.Log("Teleporting to point 4");
                        transform.localScale += new Vector3(1f, 1f, 1f);
                        break;

                    case 4:
                        Debug.Log("Teleporting to point 5");
                        transform.localScale += new Vector3(1f, 1f, 1f);
                        break;

                    case 5:
                        Debug.Log("Teleporting to point 6");
                        transform.localScale += new Vector3(1f, 1f, 1f);
                        break;

                    case 6:
                        Debug.Log("Teleporting to point 7");
                        transform.localScale += new Vector3(1f, 1f, 1f);
                        break;
                }

                currentPointIndex++;
                teleportTimer = Random.Range(4f, 8f);
            }
        }
        else
        {
            teleportTimer -= Time.deltaTime;
        }
    }

    if (gameTimer <= 0f)
    {
        Debug.Log("You survived!");
        gameEnded = true;
    }
    else if (currentPointIndex >= teleportPoints.Length)
    {
        Debug.Log("You lose!");
        gameEnded = true;
    }
}
}