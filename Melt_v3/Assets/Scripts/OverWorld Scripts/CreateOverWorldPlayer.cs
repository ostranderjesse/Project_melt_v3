
using UnityEngine;

public class CreateOverWorldPlayer : MonoBehaviour
{

    //variables
    public Transform startPosition;
    public GameObject player;

    public OverWorldPlayerMovementScript OWPlayerMovementRef;

    //purchased Skin
    public GameObject activePlayerSkin; // purchased skin
    [Space]
    public bool SkinChangerActive = false;


    private void Awake()
    {
        #region how to check for purchased skins
        //check to see player is using a different character skin.
        // if different model = yes use activly selected character model.

        /*
         how to do: sudo: if skin purchased = true check to see which ones are bought
                            next ditermin what one is active
                            make the public GameObject instatiate the players active skin
                            Gameobject player = purchasedSkin. then instantiate the player GameObject.
         */
        #endregion

        if(SkinChangerActive != false) // if true
        {
            player = activePlayerSkin;
        }
        else // if false
        {
            //do nothing

            Debug.Log("Player GameObject = Player GameObject" + player + "ActivePlayerSkin =" + activePlayerSkin);
        }


        Instantiate(player);

        player = GameObject.FindGameObjectWithTag("OWPlayer"); // Overworld Player

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("OWPlayer");
        }


        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("OWPlayer");
        }

        if (player != null)
        {
             OWPlayerMovementRef = FindObjectOfType<OverWorldPlayerMovementScript>();
        }

    }



    // Start is called before the first frame update
    void Start()
    {
        /* goes in create overworld character*/
        if (PlayerPrefs.HasKey("newPlayerPositionX")) // if playerprefs has a newPlayerPostionX then it has a newPlayerPostionY and Z
        {
            Debug.Log("Saved Data found preparing to inisialize data to spawnpoint");

            startPosition.transform.position = new Vector3(PlayerPrefs.GetFloat("newPlayerPositionX"),
                PlayerPrefs.GetFloat("newPlayerPositionY"), PlayerPrefs.GetFloat("newPlayerPositionZ"));

            Debug.Log("X position:" + PlayerPrefs.GetFloat("newPlayerPositionX"));
            Debug.Log("Y position:" + PlayerPrefs.GetFloat("newPlayerPositionY"));
            Debug.Log("Z position:" + PlayerPrefs.GetFloat("newPlayerPositionZ"));

            OWPlayerMovementRef.controller.enabled = false;
            player.transform.position = startPosition.transform.position;
            OWPlayerMovementRef.controller.enabled = true;
        }
        else
        {
            Debug.Log("No saved Data found starting new game player location at:" + startPosition.transform.position + "Default start position");

            OWPlayerMovementRef.controller.enabled = false;
            player.transform.position = startPosition.transform.position;
            OWPlayerMovementRef.controller.enabled = true;
        }
    }


}
