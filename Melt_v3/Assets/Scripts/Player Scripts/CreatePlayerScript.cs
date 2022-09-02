using UnityEngine;

public class CreatePlayerScript : MonoBehaviour
{

    //variables
    public Transform startPosition;
    public GameObject player;

    //particle effects
    public GameObject spawnParticle;

    public PlayerMovementScript playerMovementRef;

    private void Awake()
    {
        Instantiate(player);

        player = GameObject.FindGameObjectWithTag("Player");

        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if(player != null)
        {
            playerMovementRef = FindObjectOfType<PlayerMovementScript>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        /* goes in create overworld character*/
        //if (PlayerPrefs.HasKey("newPlayerPositionX")) // if playerprefs has a newPlayerPostionX then it has a newPlayerPostionY and Z
        //{
        //    Debug.Log("Saved Data found preparing to inisialize data to spawnpoint");

        //    startPosition.transform.position = new Vector3(PlayerPrefs.GetFloat("newPlayerPositionX"),
        //        PlayerPrefs.GetFloat("newPlayerPositionY"), PlayerPrefs.GetFloat("newPlayerPositionZ"));

        //    Debug.Log("X position:" + PlayerPrefs.GetFloat("newPlayerPositionX"));
        //    Debug.Log("Y position:" + PlayerPrefs.GetFloat("newPlayerPositionY"));
        //    Debug.Log("Z position:" + PlayerPrefs.GetFloat("newPlayerPositionZ"));

        //    playerMovementRef.controller.enabled = false;
        //    player.transform.position = startPosition.transform.position;
        //    playerMovementRef.controller.enabled = true;
        //}
        //else
        //{
        //    Debug.Log("No saved Data found starting new game player location at:" + startPosition.transform.position + "Default start position");

        //    playerMovementRef.controller.enabled = false;
        //    player.transform.position = startPosition.transform.position;
        //    playerMovementRef.controller.enabled = true;
        //}

            playerMovementRef.controller.enabled = false;
            player.transform.position = startPosition.transform.position;
            playerMovementRef.controller.enabled = true;




    }
}
