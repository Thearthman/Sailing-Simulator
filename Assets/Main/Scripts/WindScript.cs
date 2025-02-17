using Unity.Mathematics;
using UnityEngine;


public class WindScript : MonoBehaviour
{
    Vector3 forceVector3;
    public float currentWindAngle, currentWindForce;


    // Start is called before the first frame update
    void Start()
    {
        currentWindAngle = 0f;
        currentWindForce = 1f;
        forceVector3 = new Vector3(math.sin(currentWindAngle), math.cos(currentWindAngle) * 0.08f, 0);
    }

    // Update is called once per frame
    void Update()
    {

        //Force Calculation Model


    }


}
