//****************************************************************************************************************************************************************
// 
// If the length button is chosen, it dumps the value accordingly into the height variable
//Attached to the length button; If measured/typed button value is >0f, sets the color of the button to green
// 
//*********************************************************************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Measure_length : MonoBehaviour
{
    public Button length;
    public Sprite selected_Sprite;
    public void Set(int y)
    {
        // know which parameter is being meaured
        Track.p_l = y;
        Track.p_w = 0;
        Track.p_h = 0;


    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // setting the particular button to green showing that the measurement is already taken
        if ( Track.length > 0f)
        {
            length.image.overrideSprite = selected_Sprite;
        }

    }
}
