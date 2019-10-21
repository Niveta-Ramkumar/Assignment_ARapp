//****************************************************************************************************************************************************************
// 
// This script takes you to Home scene
//Attached to home button
// 
//*********************************************************************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Load_Home : MonoBehaviour
{
    public int x = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Function to change the value on button click
    public void Setter(int y)
    {
        x = y;
    }
    // Update is called once per frame
    void Update()
    {
        if (x == 1)
        {
            //Load the scene on button click
            SceneManager.LoadScene("Home");

        }

    }
}
