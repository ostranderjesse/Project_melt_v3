using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public void GameStart()
    {
        //change this to tutorial level later
        SceneManager.LoadScene("OverWorld"); // overworld
    }


    //public void CreditsArea()
    //{
    //    SceneManager.LoadScene("Credits");
    //}

    public void DeleteSaveFiles()
    {
        PlayerPrefs.DeleteAll();

        Debug.Log("Deleted All saved File Information");
    }


}
