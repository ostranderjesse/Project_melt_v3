using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel3 : MonoBehaviour
{


    public void StoreToOverWorld()
    {
        PlayerPrefs.GetInt("LevelsUnlocked");







        if (PlayerPrefs.GetInt("LevelsUnlocked", 3) == 3) //,3
        {

            //Debug.Log(other.tag + "is the player and is inside the block do something");

            SceneManager.LoadScene("OverWorld");// name of overworld scene here

            PlayerPrefs.SetFloat("newPlayerPositionX", 10.72f); // .f is the location of the new start postion
            PlayerPrefs.SetFloat("newPlayerPositionY", 16.84f);
            PlayerPrefs.SetFloat("newPlayerPositionZ", 17.14681f);

            PlayerPrefs.SetInt("LevelsUnlocked", 4);

            Debug.Log("LevelsUnlocked =: " + "4");
        }
        else
        {
           // Debug.Log(other.tag + "is the player and is inside the block do something");

            SceneManager.LoadScene("OverWorld");// name of overworld scene here

            PlayerPrefs.SetFloat("newPlayerPositionX", 10.72f); // .f is the location of the new start postion
            PlayerPrefs.SetFloat("newPlayerPositionY", 16.84f);
            PlayerPrefs.SetFloat("newPlayerPositionZ", 17.14681f);
        }
    }



}
