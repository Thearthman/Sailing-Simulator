using Unity.Mathematics;
using UnityEngine;

public class BoatControllerPlus : MonoBehaviour
{
    public MastController mc;
    public RudderController rc;
    public Rigidbody boatRigidbody;
    public HingeJoint hull;
    public Transform pivotPoint;
    public float boatHeadingTargetAngle = 0f;
    public float mastOptimalAngle = 0f;
    public float overallPower = 15f;
    public float outputResulted = 0f;

    private JointSpring jointSpring;
    private float boatCurrentAngle = 0f;
    private float deltaAngle = 0f;

    void Start()
    {
        boatRigidbody = GetComponent<Rigidbody>();
        jointSpring = hull.spring;

    }

    void Update()
    {
/*        if (Input.GetKey(KeyCode.J))
        {
            boatCurrentAngle -= 1f;
        }
        if (Input.GetKey(KeyCode.L))
        {
            boatCurrentAngle += 1f;
        }*/

        if (Input.GetKey(KeyCode.I))
        {
            overallPower += 0.1f;
        }
        if (Input.GetKey(KeyCode.K))
        {
            overallPower -= 0.1f;
        }

        //Rudder Interaction
        boatHeadingTargetAngle = 
            boatHeadingTargetAngle + math.sign(rc.rudderAngle)*math.clamp(math.abs(rc.rudderAngle)-10,0,180)/50;


        boatHeadingTargetAngle = math.clamp(boatHeadingTargetAngle, -180f, 180f);
        jointSpring.targetPosition = boatHeadingTargetAngle;
        hull.spring = jointSpring;

        // Debug.Log("boatAngle:" + boatHeadingTargetAngle);




        //Optimal Angle Calculation
        boatCurrentAngle = boatHeadingTargetAngle;

        if (boatCurrentAngle < 110f && boatCurrentAngle > -110f)
        {
            mastOptimalAngle = boatCurrentAngle / 3;
        }
        else if (boatCurrentAngle >= 110f)
        {
            mastOptimalAngle = (16f / 21f) * boatCurrentAngle - (330f / 7f);
        }
        else if (boatCurrentAngle <= -110f)
        {
            mastOptimalAngle = -(-(16f / 21f) * boatCurrentAngle - (330f / 7f));
        }


        //Output Calculation

        deltaAngle = math.abs(mastOptimalAngle) - math.abs(mc.mastAngle);
        if (mastOptimalAngle < 0 && mc.mastAngle < 0)
        {

        }
        else if (mastOptimalAngle < 0 && mc.mastAngle > 0)
        {

        }
        else if (mastOptimalAngle > 0 && mc.mastAngle < 0)
        {

        }
        else if (mastOptimalAngle > 0 && mc.mastAngle > 0)
        {

        }
        outputResulted = math.clamp(overallPower - math.abs(deltaAngle), 0, overallPower);




        //Debug.Log("Optimal Angle" + mastOptimalAngle);
        //Debug.Log("Mast Angle" + mc.mastAngle);
        //Debug.Log("OUTPUT: " + outputResulted);


    }

}
