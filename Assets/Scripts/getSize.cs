using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getSize : MonoBehaviour
{
    private bool isClicked = false;
    
    void Update()
    {
        if (send.sp.IsOpen)
        {
            int read = send.sp.ReadByte();
            print(read);

            try
            {
                if(read == 1)
                {
                    if (isClicked == true)
                    {
                        print("change color");
                        GetComponent<Renderer>().material.color = Color.blue;  
                    }
                }
                
                                
            }
            catch (System.Exception)
            { }
        } 
    }
    
     void OnMouseDown()
    {
        send.sendSize(transform.localScale.x);
        isClicked = true;
    }
    
}
