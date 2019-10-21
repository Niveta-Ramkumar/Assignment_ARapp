//****************************************************************************************************************************************************************
// 
// This script takes you to the measure scene
//Attached to back button
// 
//*********************************************************************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Load_Measure : MonoBehaviour
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
            SceneManager.LoadScene("Measure");

        }

    }
}
