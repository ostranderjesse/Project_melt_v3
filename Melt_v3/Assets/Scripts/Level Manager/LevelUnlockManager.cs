using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlockManager : MonoBehaviour
{

    //public List<GameObject> levelObjects;
   [SerializeField] private GameObject[] levelUnlockObjects;
    [SerializeField] private GameObject[] WorldsUnlocked;
    [SerializeField] private bool[] unclockedWorlds;
    [SerializeField] private bool[] unclockedLevels;

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

        //level unlock checker
        if (levelReached == 1)
        {
            unclockedLevels[0] = true;
        }
        else if (levelReached == 2)
        {
            unclockedLevels[0] = true;
            unclockedLevels[1] = true;
        }
        else if (levelReached == 3)
        {
            unclockedLevels[0] = true;
            unclockedLevels[1] = true;
            unclockedLevels[2] = true;
            //unclockedLevels[3] = true;
           // unclockedLevels[4] = true;
           // unclockedLevels[5] = true;
           // unclockedLevels[6] = true;
           // unclockedLevels[7] = true;
           // unclockedLevels[8] = true;
           // unclockedLevels[9] = true;
           // unclockedLevels[10] = true;
           // unclockedLevels[11] = true;
        }
        else if (levelReached == 4)
        {
            unclockedLevels[0] = true;
            unclockedLevels[1] = true;
            unclockedLevels[2] = true;
            unclockedLevels[3] = true;
            // unclockedLevels[4] = true;
            // unclockedLevels[5] = true;
            // unclockedLevels[6] = true;
            // unclockedLevels[7] = true;
            // unclockedLevels[8] = true;
            // unclockedLevels[9] = true;
            // unclockedLevels[10] = true;
            // unclockedLevels[11] = true;
        }
        else if (levelReached == 5)
        {
            unclockedLevels[0] = true;
            unclockedLevels[1] = true;
            unclockedLevels[2] = true;
            unclockedLevels[3] = true;
            unclockedLevels[4] = true;
            // unclockedLevels[5] = true;
            // unclockedLevels[6] = true;
            // unclockedLevels[7] = true;
            // unclockedLevels[8] = true;
            // unclockedLevels[9] = true;
            // unclockedLevels[10] = true;
            // unclockedLevels[11] = true;
        }
        else if (levelReached == 6)
        {
            unclockedLevels[0] = true;
            unclockedLevels[1] = true;
            unclockedLevels[2] = true;
            unclockedLevels[3] = true;
            unclockedLevels[4] = true;
            unclockedLevels[5] = true;
            // unclockedLevels[6] = true;
            // unclockedLevels[7] = true;
            // unclockedLevels[8] = true;
            // unclockedLevels[9] = true;
            // unclockedLevels[10] = true;
            // unclockedLevels[11] = true;
        }
        else if (levelReached == 7)
        {
            unclockedLevels[0] = true;
            unclockedLevels[1] = true;
            unclockedLevels[2] = true;
            unclockedLevels[3] = true;
            unclockedLevels[4] = true;
            unclockedLevels[5] = true;
            unclockedLevels[6] = true;
            // unclockedLevels[7] = true;
            // unclockedLevels[8] = true;
            // unclockedLevels[9] = true;
            // unclockedLevels[10] = true;
            // unclockedLevels[11] = true;
        }
        else if (levelReached == 8)
        {
            unclockedLevels[0] = true;
            unclockedLevels[1] = true;
            unclockedLevels[2] = true;
            unclockedLevels[3] = true;
            unclockedLevels[4] = true;
            unclockedLevels[5] = true;
            unclockedLevels[6] = true;
            unclockedLevels[7] = true;
            // unclockedLevels[8] = true;
            // unclockedLevels[9] = true;
            // unclockedLevels[10] = true;
            // unclockedLevels[11] = true;
        }
        else if (levelReached == 9)
        {
            unclockedLevels[0] = true;
            unclockedLevels[1] = true;
            unclockedLevels[2] = true;
            unclockedLevels[3] = true;
            unclockedLevels[4] = true;
            unclockedLevels[5] = true;
            unclockedLevels[6] = true;
            unclockedLevels[7] = true;
            unclockedLevels[8] = true;
            // unclockedLevels[9] = true;
            // unclockedLevels[10] = true;
            // unclockedLevels[11] = true;
        }
        else if (levelReached == 10)
        {
            unclockedLevels[0] = true;
            unclockedLevels[1] = true;
            unclockedLevels[2] = true;
            unclockedLevels[3] = true;
            unclockedLevels[4] = true;
            unclockedLevels[5] = true;
            unclockedLevels[6] = true;
            unclockedLevels[7] = true;
            unclockedLevels[8] = true;
            unclockedLevels[9] = true;
            // unclockedLevels[10] = true;
            // unclockedLevels[11] = true;
        }
        else if (levelReached == 11)
        {
            unclockedLevels[0] = true;
            unclockedLevels[1] = true;
            unclockedLevels[2] = true;
            unclockedLevels[3] = true;
            unclockedLevels[4] = true;
            unclockedLevels[5] = true;
            unclockedLevels[6] = true;
            unclockedLevels[7] = true;
            unclockedLevels[8] = true;
            unclockedLevels[9] = true;
            unclockedLevels[10] = true;
            // unclockedLevels[11] = true;
        }
        else if (levelReached == 12)
        {
            unclockedLevels[0] = true;
            unclockedLevels[1] = true;
            unclockedLevels[2] = true;
            unclockedLevels[3] = true;
            unclockedLevels[4] = true;
            unclockedLevels[5] = true;
            unclockedLevels[6] = true;
            unclockedLevels[7] = true;
            unclockedLevels[8] = true;
            unclockedLevels[9] = true;
            unclockedLevels[10] = true;
            unclockedLevels[11] = true;
        }


        //worlds unlocked checker
        if (worldReached == 1)
        {
            unclockedWorlds[0] = true;
        }
        else if (worldReached == 2)
        {
            unclockedWorlds[0] = true;
            unclockedWorlds[1] = true;
        }
        else if (worldReached == 3)
        {
            unclockedWorlds[0] = true;
            unclockedWorlds[1] = true;
            unclockedWorlds[2] = true;
        }






        for (int i = 0; i < levelUnlockObjects.Length; i++)
        {
                if (i + 1 > levelReached) // i = 0 0 + 1 = 1 if 1 > levelReached set object to false if < levelReached set active to true.
                {
                PlayerPrefs.GetInt("LevelsUnlocked");
                    levelUnlockObjects[i].SetActive(false);

                //unclockedLevels[i] = false; // true

                }
            //unclockedLevels[i] = true; // true

        }

        for(int i = 0; i < WorldsUnlocked.Length; i++)
        {
            if(i + 1 > worldReached)
            {
                PlayerPrefs.GetInt("WorldUnlocked");
                WorldsUnlocked[i].SetActive(false);

                unclockedWorlds[i] = false;

            }
        }

        




    }

}
