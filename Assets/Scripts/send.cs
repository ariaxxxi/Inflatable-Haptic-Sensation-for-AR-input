using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class send : MonoBehaviour
{
    public static SerialPort sp = new SerialPort("/dev/cu.usbserial-A50285BI",115200);
    public string message2;
    // float timePassed = 0.0f;
    

    void Start()
    {
        sp.Open();
    }

    void Update()
    {
        message2 = sp.ReadLine();
    }


    void OnApplicationQuit()
    {
        sp.Close();
    }

    public static void sendSize(float size)
    {
        print("clicked");
        sp.Write(string.Format("{0:N2}",size));
    }

}
