﻿using UnityEngine;
using UnityEngine.SceneManagement;


public class StartLevel1 : MonoBehaviour
{

    public bool isInside = false;


    public void Start()
    {
        isInside = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "OWPlayer")
        {
            isInside = true;
            Debug.Log(other.tag + "is the player and is inside the block do something");

            //if(Input.GetKeyDown(KeyCode.K))
            //{
            //    Debug.Log(other.tag + "k was pressed");
            //    SceneManager.LoadScene("test_demoV1");// name of overworld scene here
            //}

            //if(Input.GetKeyDown("space"))
            //{
            //    SceneManager.LoadScene("test_demoV1");// name of overworld scene here
            //}
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "OWPlayer")
        {
            isInside = false;
        }
    }





    public void Update()
    {
        if (isInside == true)
        {
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("test_demoV1");// name of overworld scene here
            }

            //if(Input.GetKeyDown(KeyCode.K))
            //{
            //    Debug.Log(other.tag + "k was pressed");
            //    SceneManager.LoadScene("test_demoV1");// name of overworld scene here
            //}



        }
        else if (!isInside )
        {
            Debug.Log("is inside level 1 = false");
        }


    }

}
