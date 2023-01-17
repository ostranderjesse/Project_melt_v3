using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class MainMenuScript : MonoBehaviour
{
  //  public  ShopManagerScript shopManagerScriptRef;


    public void Awake()
    {
        // shopManagerScriptRef = GetComponent<ShopManagerScript>();
        //string json = Application.persistentDataPath + "UnlockMatrix.json";

        if (File.Exists(Application.persistentDataPath + "UnlockMatric.json"))
        {
            Debug.Log("unlockmatrixpath exists");
        }
        else if (!File.Exists(ShopManagerScript.unlockMatrixPath))
        {
            Debug.Log("unlockableMatrixPath doe not exist finally this is the awake funtion ");
        }

    }

    public void Update()
    {
       // Debug.Log("saved data:" + JsonUtility.FromJson())
    }

    public void GameStart()
    {
        //change this to tutorial level later
        SceneManager.LoadScene("OverWorld"); // overworld
    }

    public void GameFileLoad() // load 
    {
        string json = Application.persistentDataPath + "UnlockMatrix.json";

        if (File.Exists(json))
        {
            SceneManager.LoadScene("OverWorld");
            //button = active
        }
        else if (!File.Exists(json))
        {
            //make button inactive
        }


    }




    public void DeleteSaveFiles()
    {
       // string unlockMatrixPath = $"{Application.persistentDataPath}/UnlockMatrix.json";
        // string json = Application.persistentDataPath + "UnlockMatrix.json";

        PlayerPrefs.DeleteAll();

        //delete binary files

    
        if (File.Exists(Application.persistentDataPath + "UnlockMatric.json"))
        {
            Debug.Log("unlockmatrixpath exists");
            //SaveSystem.WipeSavedData();

        }
        else if(!File.Exists(Application.persistentDataPath + "UnlockMatric.json"))
        {
            Debug.Log("unlockableMatrixPath does not exist  this is the delete function you made");
        }
    }

}
