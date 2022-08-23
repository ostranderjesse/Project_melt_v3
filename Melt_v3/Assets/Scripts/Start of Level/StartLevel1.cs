using UnityEngine;
using UnityEngine.SceneManagement;


public class StartLevel1 : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "OWPlayer")
        {
            Debug.Log(other.tag + "is the player and is inside the block do something");

            if(Input.GetKeyDown(KeyCode.K))
            {
                SceneManager.LoadScene("test_demoV1");// name of overworld scene here
            }
        }
    }

}
