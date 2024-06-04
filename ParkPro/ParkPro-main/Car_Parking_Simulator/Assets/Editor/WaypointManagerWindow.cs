
using UnityEngine;
using UnityEditor;

public class WaypointManagerWindow : EditorWindow
{
    [MenuItem("Window/Waypoint")]
    public static void ShowWindow()
    {
        GetWindow<WaypointManagerWindow>("Waypoint");
    }
    public Transform _orginWaypoint;
    private void OnGUI()
    {
        SerializedObject obj = new SerializedObject(this);

        EditorGUILayout.PropertyField(obj.FindProperty("_orginWaypoint"));

        if (_orginWaypoint == null)
        {
            EditorGUILayout.HelpBox("Assign a origin transform ", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginVertical("Box");
            createButtons();
            EditorGUILayout.EndVertical();
        }
        obj.ApplyModifiedProperties();
    }

    void createButtons()
    {
        if (GUILayout.Button("Create Waypoint"))
            createwaypoint();
       
    }

    void createwaypoint()
    {
        GameObject _waypointGameObject = new GameObject("waypoint" + _orginWaypoint.childCount, typeof(Waypoint));
        _waypointGameObject.transform.SetParent(_orginWaypoint, false);
        Waypoint waypoint = _waypointGameObject.GetComponent<Waypoint>();

        if (_orginWaypoint.childCount > 0)
        {
            waypoint._previousWaypoint = _orginWaypoint.GetChild(_orginWaypoint.childCount - 2).GetComponent<Waypoint>();
            waypoint._previousWaypoint._nextWaypoint = waypoint;
            waypoint.transform.position = waypoint._previousWaypoint.transform.position;
            waypoint.transform.forward = waypoint._previousWaypoint.transform.forward;
        }

        Selection.activeGameObject = waypoint.gameObject;
    }
   
}
