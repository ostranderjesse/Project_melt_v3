
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartLevel2 : MonoBehaviour
{
    public bool isInsideLevel2 = false;


    public void Start()
    {
        isInsideLevel2 = false;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "OWPlayer")
        {
            isInsideLevel2 = true;
            Debug.Log(other.tag + "is the player and is inside the block do something");

            //if(Input.GetKeyDown(KeyCode.K))
            //{
            //    Debug.Log(other.tag + "k was pressed");
            //    SceneManager.LoadScene("test_demoV1");// name of overworld scene here
            //}

            if (Input.GetKeyDown("space"))
            {

                SceneManager.LoadScene("test_demoV2");// name of overworld scene here

                Debug.Log("Level 2 entered");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "OWPlayer")
        {
            isInsideLevel2 = false;
        }
    }



    public void Update()
    {
        if (isInsideLevel2 == true)
        {
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("test_demoV2");// name of overworld scene here
            }

            //if(Input.GetKeyDown(KeyCode.K))
            //{
            //    Debug.Log(other.tag + "k was pressed");
            //    SceneManager.LoadScene("test_demoV1");// name of overworld scene here
            //}



        }
        else if (!isInsideLevel2)
        {
            Debug.Log("is inside level 1 = false");
        }
    }
}
