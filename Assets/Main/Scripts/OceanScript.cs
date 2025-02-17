using UnityEngine;
using Unity.Mathematics;

public class OceanScript : MonoBehaviour
{
    public Rigidbody boat;
    Vector3 forceVector3;
    static float currentRadiant;
    public float currentOceanAngle, currentOceanForce;

    // Start is called before the first frame update
    void Start()
    {
        currentOceanAngle = 90f;
        currentOceanForce = 5f;
        forceVector3 = new Vector3(math.sin(currentOceanAngle), math.cos(currentOceanAngle) * 0.08f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        currentRadiant = math.radians(currentOceanAngle);
        forceVector3 = new Vector3(math.sin(currentRadiant), 0, math.cos(currentRadiant));
        boat.AddForce(forceVector3 * currentOceanForce, ForceMode.Force);

        if (Input.GetKey(KeyCode.U))
        {
            currentOceanAngle += 5f;
        }

        if (Input.GetKey(KeyCode.O))
        {
            currentOceanAngle -= 5f;
        }

        // Debug.Log(forceVector3);
    }
}
