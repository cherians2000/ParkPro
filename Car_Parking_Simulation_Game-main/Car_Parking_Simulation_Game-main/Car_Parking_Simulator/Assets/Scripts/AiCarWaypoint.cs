using UnityEngine;

public class AiCarWaypoint : MonoBehaviour
{
    [Header("Opponent Car")]
    public AiCarController aiCar;
    public Waypoint currentWaypoint;
    public Waypoint initialWaypoint; // Store the initial waypoint here

    private void Awake()
    {
        aiCar = GetComponent<AiCarController>();
    }

    private void Start()
    {
        aiCar.LocateDestination(currentWaypoint.Getposition());
        initialWaypoint = currentWaypoint; // Set the initial waypoint
    }

    private void Update()
    {
        if (aiCar.destinationReached)
        {
            if (currentWaypoint._nextWaypoint != null)
            {
                currentWaypoint = currentWaypoint._nextWaypoint;
            }
            else
            {
                // If the current waypoint is the last one, set it back to the initial waypoint
                currentWaypoint = initialWaypoint;
            }

            aiCar.LocateDestination(currentWaypoint.Getposition());
        }
    }
}
