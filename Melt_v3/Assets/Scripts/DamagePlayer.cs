using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private LevelManager levelManagerRef;

    [SerializeField]
    private PlayerHealth playerHealthRef;

    [SerializeField]
    private PlayerMovementScript playerMovementRef;

    public float directionToBePushed = 2.0f;

    public float damageToGive = 10.0f;

    void Start()
    {
        levelManagerRef = FindObjectOfType<LevelManager>();

        playerHealthRef = FindObjectOfType<PlayerHealth>();

        playerMovementRef = FindObjectOfType<PlayerMovementScript>();

        if (levelManagerRef == null)
        {
            levelManagerRef = FindObjectOfType<LevelManager>();
        }

        if (playerHealthRef == null)
        {
            playerHealthRef = FindObjectOfType<PlayerHealth>();
        }

        if (playerMovementRef == null)
        {
            playerMovementRef = FindObjectOfType<PlayerMovementScript>();
        }
    }

    private void Update()
    {
        if (levelManagerRef == null)
        {
            levelManagerRef = FindObjectOfType<LevelManager>();
        }

        if (playerHealthRef == null)
        {
            playerHealthRef = FindObjectOfType<PlayerHealth>();
        }

        if (playerMovementRef == null)
        {
            playerMovementRef = FindObjectOfType<PlayerMovementScript>();
        }


    }

    public void SpawnParticlesOnHit()
    {
        Debug.Log("Player got damaged please spawn particles");
        StartCoroutine("SpawnParticlesOnHitCo");

        //
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            playerMovementRef.controller.enabled = false; // character controller
          
            playerMovementRef.enabled = false;
            Debug.Log("Playermovement = false");
            
            
            



            //kockback player
            playerMovementRef.player.transform.position = playerMovementRef.player.transform.position + new Vector3(2.5f,0f,0f);


            FindObjectOfType<PlayerHealth>().DamagePlayer(damageToGive, playerMovementRef.player.transform.position);




            playerMovementRef.controller.enabled = true; // character controller

            playerMovementRef.enabled = true;
        }
    }


  


    public IEnumerator SpawnParticlesOnHitCo()
    {
        Debug.Log("Player got damaged please spawn particles");

        Instantiate(levelManagerRef.deathParticle,playerMovementRef.transform.position, playerMovementRef.transform.rotation);
        playerMovementRef.enabled = false;
        levelManagerRef.gravityStore = playerMovementRef._gravity;
        playerMovementRef._gravity = 0f;
        Debug.Log("Hit player Respawning now");

        yield return new WaitForSeconds(levelManagerRef.respawnDelay);

        playerMovementRef._gravity = levelManagerRef.gravityStore;

        playerMovementRef.controller.enabled = false;
        playerMovementRef.transform.position = levelManagerRef.currentCheckPoint.transform.position;
        playerMovementRef.controller.enabled = true;

        playerMovementRef.enabled = true;

       levelManagerRef.THEPLAYER.SetActive(true);

        

        //create respawn particle
        Instantiate( levelManagerRef.respawnPartilcle, levelManagerRef.currentCheckPoint.transform.position, levelManagerRef.currentCheckPoint.transform.rotation);

    }
}