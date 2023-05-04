using System.IO.Ports;
using UnityEngine;

public class ArduinoController : MonoBehaviour
{
    SerialPort serialPort;

    void Start()
    {
        // Set up the serial port
        serialPort = new SerialPort("COM9", 9600);
        serialPort.Open();
    }

    void Update()
    {
        // Send data to the Arduino when the input is received
        if (Input.GetKey(KeyCode.Space))
        {
            serialPort.Write("1"); // Send "1" to the serial port
        }
    }

    void OnApplicationQuit()
    {
        // Close the serial port when the application quits
        serialPort.Close();
    }

    void SendArduinoMessage()
    {
        serialPort.Write("1");
    }
}
