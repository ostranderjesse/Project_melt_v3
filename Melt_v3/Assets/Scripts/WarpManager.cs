using System.Collections;
using UnityEngine;

public class WarpManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] warpEnterence; //warp enterenece 1
    public GameObject[] warp2Location; // warp exit 1

    public bool playerInTrigger;


    public PlayerMovementScript playermovmentRef;


    private void Start()
    {
        playermovmentRef = FindObjectOfType<PlayerMovementScript>();

        playerInTrigger = false;

        if (playermovmentRef == null)
        {
            Debug.Log("PlayermovementRef is null");
        }

        //player = GameObject.FindGameObjectWithTag("Player");

        warpEnterence = GameObject.FindGameObjectsWithTag("Warp");
        warp2Location = GameObject.FindGameObjectsWithTag("ExitWarp");
    }


    private void Update()
    {
        if (playerInTrigger == true)
        {
            StartCoroutine(WaitforTeleport());
            StopCoroutine(WaitforTeleport());
        }

    }


    public void OnTriggerEnter(Collider other)
    {
        //show teleport animation
        //diable movment until teleported
        //teleport player
        //reinable movment 

        if(other.gameObject.tag == "Player" )//&& thisArea.gameObject.name == "warpin1")
        {

            playerInTrigger = true;


            //StartCoroutine(WaitforTeleport());
            //StopCoroutine(WaitforTeleport());

            //playermovmentRef.controller.enabled = false;

            //playermovmentRef.enabled = false;

            //playermovmentRef.player.transform.position = warp2Location[0].transform.position; // [0] should be position 1 in array

            //playermovmentRef.controller.enabled = true;

            //playermovmentRef.enabled = true;

        }
        else if (other.gameObject.tag != "Player")
        {
            playerInTrigger = false;
        }

    }



    IEnumerator WaitforTeleport()
    {
        Debug.Log("Started coroutine at timestamp:" + Time.time);

        yield return new WaitForSeconds(5);



        playermovmentRef.controller.enabled = false;

        playermovmentRef.enabled = false;

        playermovmentRef.player.transform.position = warp2Location[0].transform.position; // [0] should be position 1 in array

        playermovmentRef.controller.enabled = true;

        playermovmentRef.enabled = true;

        Debug.Log("Stopped coroutine at timestamp:" + Time.time);

    }


}
