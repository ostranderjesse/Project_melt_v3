using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlockManager : MonoBehaviour
{

    //public List<GameObject> levelObjects;
   [SerializeField] private GameObject[] levelUnlockObjects;
    [SerializeField] private GameObject[] WorldsUnlocked;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        int worldReached = PlayerPrefs.GetInt("WorldUnlocked", 1);


        int levelReached = PlayerPrefs.GetInt("LevelsUnlocked", 1); // defualt = 1


        Debug.Log("WorldsReached =: " + worldReached);
        Debug.Log("levelReached =: " + levelReached);



        for (int i = 0; i < levelUnlockObjects.Length; i++)
        {
                if (i + 1 > levelReached) // i = 0 0 + 1 = 1 if 1 > levelReached set object to false if < levelReached set active to true.
                {
                PlayerPrefs.GetInt("LevelsUnlocked");
                    levelUnlockObjects[i].SetActive(false);
                }
        }

        for(int i = 0; i < WorldsUnlocked.Length; i++)
        {
            if(i + 1 > worldReached)
            {
                PlayerPrefs.GetInt("WorldUnlocked");
                WorldsUnlocked[i].SetActive(false);
            }
        }


    }

}
