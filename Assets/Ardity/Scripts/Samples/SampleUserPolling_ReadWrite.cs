/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;

/**
 * Sample for reading using polling by yourself, and writing too.
 */
public class SampleUserPolling_ReadWrite : MonoBehaviour
{
    public SerialController serialController;
    public MastController mc;
    
    // Initialization
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();

        Debug.Log("Press A or Z to execute some actions");
    }

    // Executed each frame
    void Update()
    {
        //---------------------------------------------------------------------
        // Send data
        //---------------------------------------------------------------------


        float mapedMastAngle = Mathf.Lerp(50f, 180f, Mathf.InverseLerp(-90f, 90f, mc.mastAngle));
        string printedMastAngle = ((int)mapedMastAngle).ToString();
        Debug.Log("printedMastAngle:" + printedMastAngle);

        serialController.SendSerialMessage(printedMastAngle);



        //---------------------------------------------------------------------
        // Receive data
        //---------------------------------------------------------------------

        string message = serialController.ReadSerialMessage();

        if (message != null)
            Debug.Log("Message arrived: " + message);


    }
}
