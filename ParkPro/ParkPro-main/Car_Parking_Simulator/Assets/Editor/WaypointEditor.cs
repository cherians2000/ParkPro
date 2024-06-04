using UnityEngine;
using UnityEditor;


[InitializeOnLoad]
public class WaypointEditor
{

    [DrawGizmo(GizmoType.Active | GizmoType.Selected | GizmoType.NonSelected)]
    public static void OnDrawSceneGizmos(Waypoint waypoint, GizmoType gizmoType)
    {
        if ((gizmoType & GizmoType.Selected) != 0)
        {
            Gizmos.color = Color.blue;
        }
        else
        {
            Gizmos.color = Color.blue * .50f;
        }
        Gizmos.DrawSphere(waypoint.transform.position, .1f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(waypoint.transform.position + (waypoint.transform.right * waypoint._waypointWidth / 2f),
            waypoint.transform.position - (waypoint.transform.right * waypoint._waypointWidth / 2f));
        if (waypoint._previousWaypoint != null)
        {
            Gizmos.color = Color.red;
            Vector3 offset = waypoint.transform.right * waypoint._waypointWidth / 2f;
            Vector3 offsetTo = waypoint._previousWaypoint.transform.right * waypoint._previousWaypoint._waypointWidth / 2f;

            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint._previousWaypoint.transform.position + offsetTo);
        }
        if (waypoint._nextWaypoint != null)
        {
            Gizmos.color = Color.green;
            Vector3 offset = waypoint.transform.right * -waypoint._waypointWidth / 2f;
            Vector3 offsetTo = waypoint._nextWaypoint.transform.right * -waypoint._nextWaypoint._waypointWidth / 2f;
            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint._nextWaypoint.transform.position + offsetTo);
        }
       
    }
}
