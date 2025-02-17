using UnityEngine;

public class CamearController : MonoBehaviour
{
    public BoatControllerPlus bcp;
    public Transform boat;
    float dx = 0, dy = 0.4F, dz = -1.3F;
    public float rotationSpeed = 2f;
    private float scrollInput;
    private Vector3 position;
    private float previousangle;

    void Start()
    {
        position = boat.position;
        float previousangle = bcp.boatHeadingTargetAngle;
    }
    void Update()
    {
        Vector3 boatHeading = bcp.transform.forward;

        float newangle = bcp.boatHeadingTargetAngle;

        Vector3 posDifference = new Vector3(dx, dy, dz);
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        dz = dz + scrollInput;
        dy = dy + scrollInput;
        transform.position = position + posDifference;


        float deltarotation = newangle - previousangle;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float horizontalRotation = mouseX * rotationSpeed;
        float verticalRotation = -mouseY * rotationSpeed;
        if (!Input.GetKey(KeyCode.Escape))
        {
            transform.RotateAround(boat.position, Vector3.up, horizontalRotation + deltarotation);
            transform.RotateAround(boat.position, transform.right, verticalRotation);
        }


        //Toggle for free motion
        if (!Input.GetKey(KeyCode.Tab))
        {
            //transform.RotateAround(boat.position, Vector3.up, boat.rotation.eulerAngles.y);
            ///Quaternion playerRotation = boat.rotation;

            //transform.rotation = playerRotation;
        }


        previousangle = newangle;


        // Debug.Log("Angle Differ: " + deltarotation);
    }


}



