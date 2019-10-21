//****************************************************************************************************************************************************************
// 
// If the height button is chosen, it dumps the value accordingly into the height variable
//Attached to the Height button; If measured/typed button value is >0f, sets the color of the button to green
// 
//*********************************************************************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Measure_height : MonoBehaviour
{
    public Button height;
    public Sprite selected_Sprite;
    // identifying the entered value
    public void Set(int y)
    {
        Track.p_h = y;
        Track.p_l = 0;
        Track.p_w = 0;


    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // setting the particular button to green showing that the measurement is already taken
        if ( Track.height > 0f)
        {
            height.image.overrideSprite = selected_Sprite;
        }

    }
}
