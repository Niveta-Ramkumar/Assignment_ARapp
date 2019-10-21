//****************************************************************************************************************************************************************
// 
// This script loads the scene that allows the user to type the dimensions ("Type_value")
//Attached to the Type button
// 
//*********************************************************************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Load_Type : MonoBehaviour
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
        // Load scene on button click
        if (m == 1)
        {
            SceneManager.LoadScene("Type_value");

        }

    }
}
