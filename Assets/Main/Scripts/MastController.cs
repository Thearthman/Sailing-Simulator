using UnityEngine;

public class MastController : MonoBehaviour
{
    private Vector3 axis;
    private JointSpring jointSpring;
    public HingeJoint mast;
    public float mastAngle = 0f;
    private float acceleration;


    void Start()
    {
        jointSpring = mast.spring;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            acceleration = 1f;
        }
        else
        {
            acceleration = .3f;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            mastAngle += acceleration;
        }

        if (Input.GetKey(KeyCode.E))
        {
            mastAngle -= acceleration;
        }

        jointSpring.targetPosition = mastAngle;
        mast.spring = jointSpring;

    }

}
