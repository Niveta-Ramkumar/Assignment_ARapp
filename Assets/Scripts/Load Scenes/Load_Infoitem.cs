//****************************************************************************************************************************************************************
// 
// This script takes you to the "Info_item" scene where you can enter a new name and features for the package
//Attached to back button
// 
//*********************************************************************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Load_Infoitem : MonoBehaviour
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

        if (m == 1)
        {
            // Load scene on button click
            SceneManager.LoadScene("Info_item");

        }

    }
}
