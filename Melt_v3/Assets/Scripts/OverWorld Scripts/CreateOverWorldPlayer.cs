
using UnityEngine;

public class CreateOverWorldPlayer : MonoBehaviour
{

    //variables
    public Transform startPosition;
    public GameObject player;

    public OverWorldPlayerMovementScript OWPlayerMovementRef;



    private void Awake()
    {
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
