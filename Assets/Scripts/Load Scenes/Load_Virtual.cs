//****************************************************************************************************************************************************************
// 
// This script loads the scene that allows the user to place the virtual package onto the car ("Virtualobj")
//Attached to the next button 
// 
//*********************************************************************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Virtual : MonoBehaviour
{
    // Function to assign value on button click
    public int mm =0;
    public void Set(int y)
    {
        mm = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Load scene on button click
        if (mm == 1)
        {
            SceneManager.LoadScene("Virtualobj");

        }

    }
}
