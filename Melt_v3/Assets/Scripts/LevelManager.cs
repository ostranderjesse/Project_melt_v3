using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckPoint;

    public PlayerMovementScript playerRef;

    public GameObject deathParticle;
    public GameObject respawnPartilcle;

    public float respawnDelay;

    //public Renderer playerRend;

    //public Renderer playerskin;

    public GameObject THEPLAYER;

    private float gravityStore;

    // Start is called before the first frame update
    void Start()
    {
        

        playerRef = FindObjectOfType<PlayerMovementScript>();
        THEPLAYER = GameObject.FindWithTag("Player");
       
        //playerRend = playerRef.GetComponentInChildren<Renderer>();

        if (playerRef == null)
        {
            playerRef = FindObjectOfType<PlayerMovementScript>();
        }

       

        if (THEPLAYER == null) // inside container
        {
            THEPLAYER = GameObject.FindWithTag("Player");
            Debug.Log("THEPLAYER null iff statment = player not found but now is");
        }
        else
            Debug.Log("THEPLAYER =  found");


    }


    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");

        
    }
    public IEnumerator RespawnPlayerCo()
    {
        Debug.Log("Player Respawn");

        //create death particle
        Instantiate(deathParticle, playerRef.transform.position, playerRef.transform.rotation);
        playerRef.enabled = false;
        THEPLAYER.SetActive(false);

        gravityStore = playerRef._gravity;
        playerRef._gravity = 0f;

        Debug.Log("Player Respawn");

        yield return new WaitForSeconds(respawnDelay);

        playerRef._gravity = gravityStore;

        playerRef.controller.enabled = false;
        playerRef.transform.position = currentCheckPoint.transform.position;
        playerRef.controller.enabled = true;

        playerRef.enabled = true;

        THEPLAYER.SetActive(true);

        //create respawn particle
        Instantiate(respawnPartilcle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
    }
}