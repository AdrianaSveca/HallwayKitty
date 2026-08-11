using UnityEngine;

public class CatMovement : MonoBehaviour
{
    [SerializeField] public Transform[] teleportPoints;

    public bool isSeen;
    public int currentPointIndex = 0;
    public GameObject catFrame;

    public float movementSpeed = 2f;

    private float teleportTimer;
    private float gameTimer = 999f;
    private bool gameEnded = false;

    public GameObject normalCat;
    public GameObject corruptedCat;
    public GameObject monsterCat;

    void Start()
    {
        catFrame.SetActive(false);
        ResetTeleportTimer();
        normalCat.SetActive(true);
        corruptedCat.SetActive(false);
        monsterCat.SetActive(false);
    }

    void Update()
    {
        if (gameEnded)
        {
            return;
        }

        gameTimer -= Time.deltaTime;

        if (!isSeen && currentPointIndex < teleportPoints.Length)
        {
            Transform targetPoint = teleportPoints[currentPointIndex];

            // Slowly creep toward the current point.
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPoint.position,
                movementSpeed * Time.deltaTime
            );

            // The teleport countdown only runs while unseen.
            teleportTimer -= Time.deltaTime;

            // If it reaches the point naturally.
            if (Vector3.Distance(
                transform.position,
                targetPoint.position
            ) < 0.1f)
            {
                ReachCurrentPoint();
            }
            // Otherwise, randomly teleport the remaining distance.
            else if (teleportTimer <= 0f)
            {
                transform.position = targetPoint.position;

                Debug.Log(
                    "Teleported to point " +
                    (currentPointIndex + 1)
                );

                ReachCurrentPoint();
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

    void ReachCurrentPoint()
    {
        Debug.Log(
            "Reached point " + (currentPointIndex + 1)
        );
        if (currentPointIndex == 1)
        {
            normalCat.SetActive(false);
            corruptedCat.SetActive(true);
        }
        else if (currentPointIndex == 3)
        {
            corruptedCat.SetActive(false);
            monsterCat.SetActive(true);
        }

        // Reveal the picture-frame cat at point 5.
        if (currentPointIndex == 4)
        {
            catFrame.SetActive(true);
        }

        currentPointIndex++;
        ResetTeleportTimer();
    }

    void ResetTeleportTimer()
    {
        teleportTimer = Random.Range(4f, 8f);
    }
}