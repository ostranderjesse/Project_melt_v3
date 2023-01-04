using UnityEngine.SceneManagement;
using UnityEngine;

public class StartLevel3Shop : MonoBehaviour
{

    public bool isInsideLevel3 = false;

    public void Start()
    {
        isInsideLevel3 = false;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "OWPlayer")
        {
            isInsideLevel3 = true;
            Debug.Log(other.tag + "is the player and is inside the block do something");

            //if(Input.GetKeyDown(KeyCode.K))
            //{
            //    Debug.Log(other.tag + "k was pressed");
            //    SceneManager.LoadScene("test_demoV1");// name of overworld scene here
            //}

            if (Input.GetKeyDown("space"))
            {

                SceneManager.LoadScene("Store Area");// name of overworld scene here

                Debug.Log("Level 3 entered");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "OWPlayer")
        {
            isInsideLevel3 = false;
        }
    }

    public void Update()
    {
        if (isInsideLevel3 == true)
        {
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("Store Area");// name of overworld scene here
            }

            //if(Input.GetKeyDown(KeyCode.K))
            //{
            //    Debug.Log(other.tag + "k was pressed");
            //    SceneManager.LoadScene("test_demoV1");// name of overworld scene here
            //}



        }
        else if (!isInsideLevel3)
        {
            Debug.Log("is inside level 3 = false");
        }
    }


}
