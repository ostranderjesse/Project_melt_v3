using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{

    // forced gameobject location for testing, change to gameobject not just flaot x y z position

    // public float x = 0.5f; // change to the location of the gameobject
    //public float y = 0.5f; // change to the location of the gameobject
    //public float z = 0.5f; // change to the location of the gameobject


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log(other.tag + "is the player and is inside the block do something");

            SceneManager.LoadScene("OverWorld");// name of overworld scene here

            PlayerPrefs.SetFloat("newPlayerPositionX", -0.56f); // .f is the location of the new start postion
            PlayerPrefs.SetFloat("newPlayerPositionY", 16.84f);
            PlayerPrefs.SetFloat("newPlayerPositionZ", 17.14681f);
        }
    }
}
