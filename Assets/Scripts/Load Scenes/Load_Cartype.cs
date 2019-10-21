//****************************************************************************************************************************************************************
// 
// This script loads the scene that allows the user to select their car
//Attached to the login button 
// 
//*********************************************************************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Load_Cartype : MonoBehaviour
{
    public int m;
    // Function to assign value on button click
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
        // load the below scene on button click
        if (m == 1)
        {
            SceneManager.LoadScene("Choose your car");

        }

    }
}
