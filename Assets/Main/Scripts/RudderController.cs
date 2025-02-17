using UnityEngine;
using Unity.Mathematics;
public class RudderController : MonoBehaviour
{

    public HingeJoint rudderJoint; // Reference to the ConfigurableJoint component.
    JointSpring jointSpring;
    public float rudderAngle = 0f;

    private float maxAngle = 45f; // Maximum angle the rudder can rotate.
    private float minAngle = -45f; // Minimum angle the rudder can rotate.
    float acceleration;
        
    void Start()
    {
        jointSpring = rudderJoint.spring;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            acceleration = 2f;
        }
        else
        {
            acceleration = 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rudderAngle -= 1f * acceleration;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rudderAngle += 1f * acceleration;
        }

        rudderAngle = math.clamp(rudderAngle, minAngle, maxAngle);
        jointSpring.targetPosition = rudderAngle;
        rudderJoint.spring = jointSpring;
    }

}
