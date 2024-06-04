using UnityEngine;

public class DirectionPointer : MonoBehaviour
{
 
    private Transform _target;
    [SerializeField]
    private float rotationSpeed;
    
   
    private void Start()
    {
        _target = GameObject.Find("ParkingStation").transform;
    }
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_target.position - transform.position),
        rotationSpeed * Time.deltaTime);
    }
}
