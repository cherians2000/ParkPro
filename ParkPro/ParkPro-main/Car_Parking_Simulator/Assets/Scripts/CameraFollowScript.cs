using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The car's transform
    public Vector3 offset = new Vector3(0, 3, -5); // Adjust this to set the camera's position relative to the car
    public float smoothSpeed = 0.125f; // Adjust this to set the smoothness of the camera movement

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target.position);
        }
    }
}
