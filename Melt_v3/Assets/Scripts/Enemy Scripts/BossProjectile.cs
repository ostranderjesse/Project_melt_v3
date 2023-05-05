using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float life = 5f;
    public GameObject spawnFactory;

    public Rigidbody rb;

    public Transform spawnPoint;

  //  private EnemyAttackScript enemyAttackScriptRef;


    public void Awake()
    {
       // Destroy(gameObject, life);
    }
    // Start is called before the first frame update
    void Start()
    {
        //enemyAttackScriptRef = FindObjectOfType<EnemyAttackScript>();


        //if (enemyAttackScriptRef == null)
        //{
        //    enemyAttackScriptRef = FindObjectOfType<EnemyAttackScript>();
        //}

        ////spawnPoint.position = gameObject.transform.position;
        ///

        rb = GetComponent<Rigidbody>();

        if (spawnPoint == null)
            return;

    }

    private void Update()
    {
        
    }


    //if hits player destroy
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.tag == "Ground")
        {
            spawnPoint.transform.position = this.gameObject.transform.position;

            Instantiate(spawnFactory, spawnPoint.position, spawnPoint.rotation); //bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Destroy(gameObject);
            Debug.Log("Factroy is spawned");
        }

        if(other.tag == "Player")
        {
            //damage player
           
            Debug.Log("Hit player");

            Destroy(gameObject);
        }
    }


}
