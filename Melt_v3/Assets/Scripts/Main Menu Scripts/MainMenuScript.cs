using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class MainMenuScript : MonoBehaviour
{
    //  public  ShopManagerScript shopManagerScriptRef;

    //public UnlockableMatrixScript unlockableMatrixRef;
    public ShopManagerScript shopManagerScriptRef;

    public UnlockableMatrixScript unlockableMatrixRef;

  [SerializeField]  public string unlockedMatrixPath;

    public void Awake()
    {
        unlockedMatrixPath = $"{Application.persistentDataPath}/UnlockMatrix.json";

        if(File.Exists(unlockedMatrixPath))
        {
            Debug.Log("File exists in path:" + unlockedMatrixPath);
            string json = File.ReadAllText(unlockedMatrixPath);
            unlockableMatrixRef = JsonUtility.FromJson<UnlockableMatrixScript>(json);
        }
        else
            Debug.Log("File doe not exist in path:" + unlockedMatrixPath);
    }

    public void Update()
    {

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

    

   

    public void DelSaveJson()
    {
        string json = JsonUtility.ToJson(unlockableMatrixRef);

        if (File.Exists(unlockedMatrixPath))
        {
            File.Delete(unlockedMatrixPath);
            unlockableMatrixRef.hasAmmoPerk1 = false;
            unlockableMatrixRef.hasDamagePerk1 = false;
            unlockableMatrixRef.hasHealthPerk1 = false;
            unlockableMatrixRef.hasHeatResistencePerk1 = false;


            Debug.Log("perks: " + unlockableMatrixRef.hasAmmoPerk1);
            Debug.Log("perks: " + unlockableMatrixRef.hasDamagePerk1);
            Debug.Log("perks: " + unlockableMatrixRef.hasHealthPerk1);
            Debug.Log("perks: " + unlockableMatrixRef.hasHeatResistencePerk1);

        }
        else
            Debug.Log("File:" + unlockedMatrixPath + " does not exist in " + unlockedMatrixPath);


        if(PlayerPrefs.HasKey("LevelsUnlocked"))
        {
            Debug.Log("Had playerprefs");
            Debug.Log("playerprefs exists! prepairing to delete");
            PlayerPrefs.DeleteAll();

            Debug.Log("Playerprefs are now deleted");
        }
        else if(!PlayerPrefs.HasKey("LevelsUnlocked"))
        {
            Debug.Log("Playerprefs were never created");
        }

    }


}
