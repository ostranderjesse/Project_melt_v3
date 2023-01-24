using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel4Boss1 : MonoBehaviour
{
    #region overworld coordenence
    // overworld location to be is
    //x 19.5f
    // y 16.84f
    //z 17.14681f
    #endregion

    public void Boss1ToOverWorld() // back button
    {
        PlayerPrefs.GetInt("LevelsUnlocked");

        if (PlayerPrefs.GetInt("LevelsUnlocked", 4) == 4) //,3
        {

            //PlayerPrefs.SetInt("WorldCompletion", 1);

            //Debug.Log(other.tag + "is the player and is inside the block do something");

            SceneManager.LoadScene("OverWorld");// name of overworld scene here

            PlayerPrefs.SetFloat("newPlayerPositionX", 19.5f); // .f is the location of the new start postion
            PlayerPrefs.SetFloat("newPlayerPositionY", 16.84f);
            PlayerPrefs.SetFloat("newPlayerPositionZ", 17.14681f);

            PlayerPrefs.SetInt("LevelsUnlocked", 5);


            Debug.Log("LevelsUnlocked =: " + "5");
        }
        else // this is the back to the prior level stuff not the above code. after fiddling with it try and delete the above codee
        {
            // Debug.Log(other.tag + "is the player and is inside the block do something");

            SceneManager.LoadScene("OverWorld");// name of overworld scene here

            PlayerPrefs.SetFloat("newPlayerPositionX", 19.5f); // .f is the location of the new start postion
            PlayerPrefs.SetFloat("newPlayerPositionY", 16.84f);
            PlayerPrefs.SetFloat("newPlayerPositionZ", 17.14681f);
        }
    }

    public void Boss1ToWorld2()
    {
        PlayerPrefs.GetInt("WorldUnlocked");
        if(PlayerPrefs.GetInt("WorldUnlocked", 1) == 1) // world beaten = 1
        {
            SceneManager.LoadScene("OverWorld");

            PlayerPrefs.SetFloat("newPlayerPositionX", -7.950007f); // .f is the location of the new start postion
            PlayerPrefs.SetFloat("newPlayerPositionY", 16.807f);
            PlayerPrefs.SetFloat("newPlayerPositionZ", 34.89f);

            PlayerPrefs.SetInt("WorldUnlocked", 2);

        }
         else
         {
            #region else statment for if you lost the boss fight or backed out
            #endregion

            SceneManager.LoadScene("OverWorld");
        // SceneManager.LoadScene("OverWorld");// name of overworld scene here

         }

        if (PlayerPrefs.GetInt("LevelsUnlocked", 4) == 4) //,3
        {
            //Debug.Log(other.tag + "is the player and is inside the block do something");

            SceneManager.LoadScene("OverWorld");// name of overworld scene here




            PlayerPrefs.SetFloat("newPlayerPositionX", 43.15147f); // .f is the location of the new start postion
            PlayerPrefs.SetFloat("newPlayerPositionY", 17.4f);
            PlayerPrefs.SetFloat("newPlayerPositionZ", 34.89f);

            PlayerPrefs.SetInt("LevelsUnlocked", 5);

            Debug.Log("LevelsUnlocked =: " + "5");
        }
        else // this is the back to the prior level stuff not the above code. after fiddling with it try and delete the above codee
        {
            #region else statment for if unlocked level is already been reached
            #endregion

            // Debug.Log(other.tag + "is the player and is inside the block do something");

            SceneManager.LoadScene("OverWorld");// name of overworld scene here

            PlayerPrefs.SetFloat("newPlayerPositionX", 43.15147f); // .f is the location of the new start postion
            PlayerPrefs.SetFloat("newPlayerPositionY", 17.4f);
            PlayerPrefs.SetFloat("newPlayerPositionZ", 34.89f);

          




        }



    }

}
