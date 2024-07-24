using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckPoint;

    public PlayerMovementScript playerRef;

    public GameObject deathParticle;
    public GameObject respawnPartilcle;

    public float respawnDelay;
    public float attackDelay;

    public GameObject THEPLAYER;

    public float gravityStore;
    [Space]
    [Space]
    [SerializeField] private EnemyAttackScript enemyAttackScriptRef;
    public List<GameObject> bulletsInExistence;
    public List<GameObject> factoryInExistence;

    //reference the bossProjectile
    //public BossProjectile bossProjectileRef;

    public BulletDetection bulletDetectionRef;


    // Start is called before the first frame update
    void Start()
    {
        bulletDetectionRef = FindObjectOfType<BulletDetection>();
        if(bulletDetectionRef == null)
        {
            bulletDetectionRef = FindObjectOfType<BulletDetection>();
        }


        playerRef = FindObjectOfType<PlayerMovementScript>();
        THEPLAYER = GameObject.FindWithTag("Player");


        enemyAttackScriptRef = FindObjectOfType<EnemyAttackScript>();

        bulletsInExistence = new List<GameObject>();
        factoryInExistence = new List<GameObject>();


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

    private void Update()
    {
       
        if (bulletDetectionRef == null)
        {
            bulletDetectionRef = FindObjectOfType<BulletDetection>();
        }
    }


    public void RemoveExtraFactory()
    {
        StartCoroutine("RemoveExtraFactoryCo");
    }

    public void RemoveObjectFromList()
    {
        StartCoroutine("RemoveObjectFromListCo");
    }



    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");      
    }


    public IEnumerator RemoveExtraFactoryCo()
    {
        Debug.Log("factory check coroutine");

        if(factoryInExistence.Count >= 1)
        {
            if (factoryInExistence.Count >1)
            {
                factoryInExistence.RemoveAt(1); // second element
            }
        }
     

        Debug.Log("Player Respawn");

        yield return new WaitForSeconds(respawnDelay);

       // Destroy(bossProjectileRef.spawnFactory);

        Destroy(bulletDetectionRef.spawnFactory);

        factoryInExistence.RemoveAt(0);

       
    }






    public IEnumerator RemoveObjectFromListCo()
    {
        Debug.Log("Remove Bullet from list Coroutine started");
        Debug.Log("Romove from bullet list");

        //create partilcle effects
       // Instantiate(deathParticle, bossProjectileRef.transform.position, bossProjectileRef.transform.rotation);

       // bulletsInExistence.RemoveAt(0);

        yield return new WaitForSeconds(attackDelay);

        bulletsInExistence.RemoveAt(0);


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

        // delay damage output somehow
    }
}