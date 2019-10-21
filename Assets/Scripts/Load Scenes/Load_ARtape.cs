//****************************************************************************************************************************************************************
// 
// This script loads the scene that allows the user to measure package using AR tape
//Attached to the Tape button 
// 
//*********************************************************************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Load_ARtape : MonoBehaviour
{
    public int x = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Function to assign value on button click
    public void Setter(int y)
    {
        x = y;
    }
    // Update is called once per frame
    void Update()
    {
        // load the scene on button click
        if (x == 1)
        {
            SceneManager.LoadScene("AR_Tape");

        }

    }
}
