using UnityEngine.SceneManagement;
using UnityEngine;

public class StartLevel4Boss1 : MonoBehaviour
{
    public bool isInsideLevel4 = false;

    public void Start()
    {
        isInsideLevel4 = false;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "OWPlayer")
        {
            isInsideLevel4 = true;
            Debug.Log(other.tag + "is the player and is inside the block do something");

            //if(Input.GetKeyDown(KeyCode.K))
            //{
            //    Debug.Log(other.tag + "k was pressed");
            //    SceneManager.LoadScene("test_demoV1");// name of overworld scene here
            //}

            //if (Input.GetKeyDown("space"))
            //{

            //    SceneManager.LoadScene("BossBattle1");// name of overworld scene here

            //    Debug.Log("Level 3 entered");
            //}
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "OWPlayer")
        {
            isInsideLevel4 = false;
        }
    }

    public void Update()
    {
        if (isInsideLevel4 == true)
        {
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("BossBattle1");// name of overworld scene here
            }

            //if(Input.GetKeyDown(KeyCode.K))
            //{
            //    Debug.Log(other.tag + "k was pressed");
            //    SceneManager.LoadScene("test_demoV1");// name of overworld scene here
            //}



        }
        else if (!isInsideLevel4)
        {
            Debug.Log("is inside level 4 = false");
        }
    }

}

