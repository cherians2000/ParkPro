using UnityEngine;
using UnityEngine.AI;

public class WayPointNavigator : MonoBehaviour
{
    public NavMeshAgent agent;

    public Waypoint currentWaypoint;

    private enum Direction
    {
        Forward,
        Backward
    }
    int direct;
    private void Awake()
    {
     
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
      
        direct = Mathf.RoundToInt(Random.Range(0f, 1f));
        agent.SetDestination(currentWaypoint.Getposition());
    }

    private Direction direction = Direction.Forward;

    private void Update()
    {
       
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            bool shouldBranch = false;

                if (direction == Direction.Forward && currentWaypoint._nextWaypoint != null)
                {
                    if(direct == 0)
                    {
                        currentWaypoint = currentWaypoint._nextWaypoint;
                    }if(direct == 1)
                    {
                        currentWaypoint = currentWaypoint._previousWaypoint;
                    }
                  
                }
                else if (direction == Direction.Backward && currentWaypoint._previousWaypoint != null)
                {
                    currentWaypoint = currentWaypoint._previousWaypoint;
                }
                else
                {
                    // Change direction if there is no valid next or previous waypoint.
                    direction = (direction == Direction.Forward) ? Direction.Backward : Direction.Forward;
                    Debug.Log("direction changedd =========!!!!!!!!");
                }
            }
       
            agent.SetDestination(currentWaypoint.Getposition());
        
        

       
        }
    }

