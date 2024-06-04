using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [Header("Waypoint Settings")]
    public Waypoint _previousWaypoint;
    public Waypoint _nextWaypoint;
 
    [Range(0f, 5f)]
    public float _waypointWidth = 1f;
    public Vector3 Getposition()
    {
        Vector3 _minbound = transform.position - transform.right * _waypointWidth / 2f;
        Vector3 _maxbound = transform.position - transform.right * _waypointWidth / 2f;

        return Vector3.Lerp(_minbound, _maxbound, Random.Range(0f, 1f));

    }
}
