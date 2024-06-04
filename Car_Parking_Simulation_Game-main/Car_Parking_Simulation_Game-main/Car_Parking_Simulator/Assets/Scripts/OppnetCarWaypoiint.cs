using UnityEngine;

public class OppnetCarWaypoiint : MonoBehaviour
{
    [Header("Opponet Car")]
    private OpponetCar opponetCar;
    [SerializeField] private Waypoint currentWaypoint;

    private void Awake()
    {
        opponetCar = GetComponent<OpponetCar>();
    }
    private void Start()
    {
            opponetCar.LocateDestination(currentWaypoint.Getposition());
    }
    private void FixedUpdate()
    {
        if(opponetCar.destinationReached)
        {
            currentWaypoint = currentWaypoint._nextWaypoint;
            opponetCar.LocateDestination(currentWaypoint.Getposition());
        }
    }
}
