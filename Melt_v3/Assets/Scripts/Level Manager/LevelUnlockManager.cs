using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlockManager : MonoBehaviour
{

    //public List<GameObject> levelObjects;
   [SerializeField] private GameObject[] levelUnlockObjects;

    private void Awake()
    {
        //levelObjects = FindGameObjectsWithTag("Level");


    }

    // Start is called before the first frame update
    void Start()
    {
        //int levelUnlocked = PlayerPrefs.SetInt("levelUnlocked", 1);
        //PlayerPrefs.SetInt("LevelUnlocked", 1);

        //if (PlayerPrefs.HasKey("LevelUnlocked"))
        //{
        //    PlayerPrefs.GetInt("LevelUnlocked");
        //}
        //else if(!(PlayerPrefs.HasKey("LevelUnlocked")))
        //{
        //    PlayerPrefs.SetInt("LevelUnlocked", 1);
        //}



        //foreach(GameObject obj in levelObjects)
        //{
        //    obj.SetActive(false);


        //    if (PlayerPrefs.HasKey("LevelUnlocked"))
        //    {
        //        PlayerPrefs.GetInt("LevelUnlocked");
        //        Debug.Log("has levelunlock number");
        //    }
        //    else if (!(PlayerPrefs.HasKey("LevelUnlocked")))
        //    {
        //        PlayerPrefs.SetInt("LevelUnlocked", 1);
        //        Debug.Log("has no levelunlock number we set it to 1");
        //    }

        //}


        int levelReached = PlayerPrefs.GetInt("LevelsUnlocked", 1); // defualt = 1

       

        Debug.Log("levelReached =: " + levelReached);


        //foreach (GameObject obj in levelObjects)
        //{
        //obj.SetActive(false);

        for (int i = 0; i < levelUnlockObjects.Length; i++)
            {
                if (i + 1 > levelReached) // i = 0 0 + 1 = 1 if 1 > levelReached set object to false if < levelReached set active to true.
                {
                PlayerPrefs.GetInt("LevelsUnlocked");
                    levelUnlockObjects[i].SetActive(false);
                }
            //if (levelReached == 2)
            //{
            //    //PlayerPrefs.GetInt("LevelsUnlocked");

            //    levelUnlockObjects[0].SetActive(true);
            //    levelUnlockObjects[1].SetActive(true);
            //}
            //if (levelReached == 3)
            //{

            //    levelUnlockObjects[0].SetActive(true);
            //    levelUnlockObjects[1].SetActive(true);
            //    levelUnlockObjects[3].SetActive(true);
            //}



        }


        //}










    }

}
