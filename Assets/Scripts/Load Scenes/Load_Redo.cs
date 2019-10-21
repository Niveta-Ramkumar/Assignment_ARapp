//****************************************************************************************************************************************************************
// 
// This script sets the static variable reload to one and reloads the "ARtape" screen; Also reassigns the measured value 
//Attached to the Reset button
// 
//*********************************************************************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Load_Redo : MonoBehaviour
{
    // Function to change the value on button click
    public int m;
    public void Setter(int y)
    {
       m = y;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Set the reset value to one only once
        if (m==1)
        {
            Track.reset = 1;
            m = 0;
        }
        else
        {
            Track.reset = 0;
        }
    }
}
