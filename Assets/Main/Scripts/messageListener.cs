using System.IO;
using System.IO.Ports;
using UnityEngine;

public class messageListener : MonoBehaviour { 
    SerialPort stream = new SerialPort("COM7", 9600);

    private void Start()
    {
        stream.Open();
    }

    private void Update()
    {


    }


}
