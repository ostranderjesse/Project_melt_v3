using UnityEngine;

public class LevelUnlockManagerScript : MonoBehaviour
{
    //variables

    public GameObject[] levelsInGame;


    private void Start()
    {
        #region unlock next level notes
        /*
         find all levels
         diables all levels but level 1
        enable level 2 if level 1 is completed
        if level 2 is completed before do not unlock a second time
         */
        #endregion

        foreach (GameObject obj in levelsInGame)
        {
            obj.SetActive(false);
        }

        int levelReached = PlayerPrefs.GetInt("ReachedLevel", 1);

        for(int i = 0; i < levelReached; i++)
        {
            levelsInGame[i].SetActive(true);
        }

    }










}
