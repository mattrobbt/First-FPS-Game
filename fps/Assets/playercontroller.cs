
using UnityEngine;

[RequireComponent(typeof(playermotor))]
public class playercontroller : MonoBehaviour
{
  [SerializeField]
  //Setting initial speed of player
  private float speed = 5f;

 //setting initial sensitivity of the mouse movement
  [SerializeField]
  private float look = 3f;



  private playermotor motor;

  void Start () 
  {
    motor = GetComponent<playermotor>();
  }  

  void Update ()
  {
    //This is a way of calculating the movement velocity in 3D vector
    float xMov = Input.GetAxisRaw("Horizontal");
    float zMov = Input.GetAxisRaw("Vertical");

    Vector3 movHorizontal = transform.right * xMov;
    Vector3 movVertical = transform.forward * zMov;

  //Final movement calculation
    Vector3 velocity = (movHorizontal + movVertical).normalized * speed;

    //Applying movement
    motor.Move(velocity);

    //Calculate rotation in 3d vector (turning around yaxis of body)
    float yRot = Input.GetAxisRaw("Mouse X");
    Vector3 rotation = new Vector3 (0f, yRot, 0f) * look;

    //Apply rotation
    motor.Rotate(rotation);




  //Calculating the camera rotation in 3d vector (turning around yaxis of body)
    float xRot = Input.GetAxisRaw("Mouse Y");
    Vector3 camerarotation = new Vector3 (xRot, 0f, 0f) * look;

    //Apply rotation
    motor.RotateCamera(camerarotation);

  }
  }

