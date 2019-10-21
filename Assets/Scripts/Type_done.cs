//****************************************************************************************************************************************************************
// 
// This script dumpd the entered dimension of the package into the static values and loads the "Measure" scene (using another script)
//Attached to the done button 
// 
//*********************************************************************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Type_done : MonoBehaviour
{
    public int mk;
    // Call function to assign value on button click
    public void Sr(int y)
    {
        mk = y;
    }
    // To store the typed value
    public InputField value;
    public float v;
    public string s;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if done is pressed check which dimension it is and assign the value correspondingly
        if (mk == 1)
        {
            s = value.text;
            v = float.Parse(s);
            
            if (Track.p_w == 1)
            {
                Track.width = v;

            }
            if (Track.p_l == 1)
            {
                Track.length = v;
            }
            if (Track.p_h == 1)
            {
                Track.height = v;
            }
        }
    }
}
