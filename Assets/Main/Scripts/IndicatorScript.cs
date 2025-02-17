using UnityEngine;

public class IndicatorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform hull;
    public BoatControllerPlus bcp;
    private float intensity;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        intensity = bcp.outputResulted/50; 
        Vector3 randomOffset = Random.insideUnitSphere * intensity;
        transform.position = hull.position + randomOffset;

    }
}
