
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnOfLevel2 : MonoBehaviour
{

    // forced gameobject location for testing, change to gameobject not just flaot x y z position

    // public float x = 0.5f; // change to the location of the gameobject
    //public float y = 0.5f; // change to the location of the gameobject
    //public float z = 0.5f; // change to the location of the gameobject


    //4.72f
    // 16.84f
    //17.14681f

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            PlayerPrefs.GetInt("LevelsUnlocked");

            if (PlayerPrefs.GetInt("LevelsUnlocked",2) == 2) //,2
            {

                Debug.Log(other.tag + "is the player and is inside the block do something");

                SceneManager.LoadScene("OverWorld");// name of overworld scene here

                PlayerPrefs.SetFloat("newPlayerPositionX", 4.72f); // .f is the location of the new start postion
                PlayerPrefs.SetFloat("newPlayerPositionY", 16.84f);
                PlayerPrefs.SetFloat("newPlayerPositionZ", 17.14681f);

                PlayerPrefs.SetInt("LevelsUnlocked", 3);

                Debug.Log("LevelsUnlocked =: " + "3");
            }
            else
            {
                Debug.Log(other.tag + "is the player and is inside the block do something");

                SceneManager.LoadScene("OverWorld");// name of overworld scene here

                PlayerPrefs.SetFloat("newPlayerPositionX", 4.72f); // .f is the location of the new start postion
                PlayerPrefs.SetFloat("newPlayerPositionY", 16.84f);
                PlayerPrefs.SetFloat("newPlayerPositionZ", 17.14681f);
            }

            //increment level unlock to 2
            //if (PlayerPrefs.HasKey("LevelsUnlocked"))
            //{
            //    if(PlayerPrefs.GetInt("LevelsUnlocked") == 1)
            //    {
            //        Debug.Log("Playerprefs = 1 exicude code: ");
            //        SceneManager.LoadScene("OverWorld");// name of overworld scene here

            //        PlayerPrefs.SetInt("LevelsUnlocked", 2);

            //        Debug.Log("Playerprefs = 2 now exicude code: newplayersavepositions ");


            //        PlayerPrefs.SetFloat("newPlayerPositionX", -0.56f); // .f is the location of the new start postion
            //        PlayerPrefs.SetFloat("newPlayerPositionY", 16.84f);
            //        PlayerPrefs.SetFloat("newPlayerPositionZ", 17.14681f);

            //        Debug.Log("Playerprefs = 2 now exicude code: newplayersavepositions  successful");


            //    }
            //else if(PlayerPrefs.GetInt("LevelsUnlocked") != 1)
            //{
            //    Debug.Log("Playerprefs level != 1 exicude code: load player in without incrementing level unlock ");



            //    SceneManager.LoadScene("OverWorld");// name of overworld scene here

            //    PlayerPrefs.SetFloat("newPlayerPositionX", -0.56f); // .f is the location of the new start postion
            //    PlayerPrefs.SetFloat("newPlayerPositionY", 16.84f);
            //    PlayerPrefs.SetFloat("newPlayerPositionZ", 17.14681f);

            //    Debug.Log("Playerprefs level != 1 exicude code: load player in without incrementing level unlock  successful");

            //}
        }

        //if(PlayerPrefs.GetInt("ReachedLevel") < )

    }
}
