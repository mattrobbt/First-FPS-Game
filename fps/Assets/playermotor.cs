
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class playermotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 camRotation = Vector3.zero;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Gets movement vector
    public void Move (Vector3 _velocity)
    {
    velocity = _velocity;
    }

    //Gets rotational vector
    public void Rotate (Vector3 _rotation)
    {
    rotation = _rotation;
    }

    //Gets rotational vector for camera
    public void RotateCamera (Vector3 _camRotation)
    {
    camRotation = _camRotation;
    }

    //Runs all physics iterations
    void FixedUpdate ()
    {
        PerformMovement();
        PerformRotation();
    }
    //Perform movement based on velocity variable

    void PerformMovement ()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotation ()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler (rotation));
        if (cam != null){
            cam.transform.Rotate(-camRotation);
        }

    }

}
