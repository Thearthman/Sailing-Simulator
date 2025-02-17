using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using Unity.VisualScripting;
using Unity.Mathematics;

public class PythonTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pythonRcvdText = null;
    [SerializeField] TextMeshProUGUI sendToPythonText = null;
    public Rigidbody Boom_Mast;
    public HingeJoint boom;
    public JointSpring jointSpring;
    float speed = 0.5f;

    string tempStr = "0.5";
    float numToSendToPython = 0.5f  ;
    UdpSocket udpSocket;


    public void UpdatePythonRcvdText(string str)
    {
        tempStr = str;
    }



    private void Start()
    {
        udpSocket = FindObjectOfType<UdpSocket>();
        jointSpring = boom.spring;


    }

    void Update()
    {   
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            speed = 1f;
        }
        else
        {
            speed= 0.5f;
        }
        pythonRcvdText.text = tempStr;
        jointSpring.targetPosition = -(float.Parse(tempStr)*360-180);
        boom.spring = jointSpring;
        if (Input.GetKey(KeyCode.I))
        {
            numToSendToPython += 0.01f*speed;
        }
        if (Input.GetKey(KeyCode.K))
        {
            numToSendToPython -= 0.01f*speed;
        }
        sendToPythonText.text = numToSendToPython.ToString();
        udpSocket.SendData(numToSendToPython.ToString());
        sendToPythonText.text = "Wind Direction: " + numToSendToPython.ToString();

    }
}
