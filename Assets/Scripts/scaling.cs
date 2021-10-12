using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class scaling : MonoBehaviour
{
    private Vector3 scaleChange;
    // public string receivedAirData;
    SerialPort airData = new SerialPort("/dev/cu.usbserial-A50285BI",9600);
    public float speed = 2f;
    public float duration = 5f;
    Vector3 startSize;
    Vector3 endSize;


    void Start()
    {
        airData.Open();
        // airData.ReadTimeout = 1;
        scaleChange = new Vector3(10,10,10);
        startSize = new Vector3(1,1,1);
        endSize = new Vector3(3,3,3);
    }

    void Update()
    {
    

        if (airData.IsOpen)
        {
            int read = airData.ReadByte();
            Debug.Log(read);

            
            try
            {
                
                if (read == 1) //inflate
                {
                    float i = 0.0f;
                    float rate = (1.0f / duration) * speed;
                    while(i < 1.0f)
                    {
                        i += Time.deltaTime * rate;
                        transform.localScale = Vector3.Lerp(startSize,endSize,i);
                    }
        
                   
                }
                if (read == 2) //deflate
                {
                    float i = 0.0f;
                    float rate = (1.0f / duration) * speed;
                    while(i < 1.0f)
                    {
                        i += rate * Time.deltaTime;
                        transform.localScale = Vector3.Lerp(endSize, startSize, i);
                    }
                }
            }
            catch (System.Exception)
            { }
            
        }


    }

    



    private static int Map(int value, int fromLow, int fromHigh, int toLow, int toHigh) 
    {
        return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
    }
} 


