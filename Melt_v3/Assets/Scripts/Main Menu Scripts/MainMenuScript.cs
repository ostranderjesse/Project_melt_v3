using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class MainMenuScript : MonoBehaviour
{

    public void GameStart()
    {
        //change this to tutorial level later
        SceneManager.LoadScene("OverWorld"); // overworld
    }

    public void GameFileLoad() // load 
    {
        string path = Application.persistentDataPath + "/Player.Perks";

        if(File.Exists(path))
        {
            SceneManager.LoadScene("OverWorld");
            //button = active
        } else if (!File.Exists(path))
        {
            //button = inactive
        }

        
    }


    //public void CreditsArea()
    //{
    //    SceneManager.LoadScene("Credits");
    //}

    public void DeleteSaveFiles()
    {
        PlayerPrefs.DeleteAll();

        //delete binary files

        SaveSystem.WipeSavedData();

        Debug.Log("Deleted All saved File Information");
    }



}
