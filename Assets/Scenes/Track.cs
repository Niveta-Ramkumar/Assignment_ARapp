//****************************************************************************************************************************************************************
// 
// Collection of all static variable to hold the values 
// In future, we can improve it using JSON
// 
//*********************************************************************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{

    // variables to hold the measured values of length/height/width
    public static float width = 0f;
    public static float length =0f;
    public static float height=0f;
    // variables to track whether length/height/width is measured
    public static int p_w = 0;
    public static int p_h = 0;
    public static int p_l = 0;
    // variable to track the reset button
    public static int reset = 0;
    public static int track = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
