﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float bulletDropTime = .05f;

    public float lifeTime = 3f;

    public GameObject spawnFactory;

    public Rigidbody rb;

    //public EnemyAttackScript enemyAttackScriptRef;

    public Transform spawnPoint;

    public float speed;

    [SerializeField]
   private EnemyAttackScript enemyAttackScriptRef; // take out code id not work right

    [SerializeField]
    private LevelManager levelManagerScriptRef;



    //testing variables area
    //lifeTime
    [SerializeField] private bool timeToDie = false;

    // Start is called before the first frame update
    void Start()
    {

        enemyAttackScriptRef = FindObjectOfType<EnemyAttackScript>();

        if(enemyAttackScriptRef == null)
        {
            enemyAttackScriptRef = FindObjectOfType<EnemyAttackScript>();
        }

        levelManagerScriptRef = FindObjectOfType<LevelManager>();

        if (levelManagerScriptRef == null)
        {
            levelManagerScriptRef = FindObjectOfType<LevelManager>();
        }

        rb = GetComponent<Rigidbody>();

        //rb.useGravity = true;


       // enemyAttackScriptRef = FindObjectOfType<EnemyAttackScript>();
       // {
            speed = -speed;
            Debug.Log("speed =" + speed);
       // }

    }

    private void Update()
    {
        // rb.velocity = new Vector3(speed, Rigidbody.velocity.y);
       // rb.AddForce(Vector3.forward * speed * Time.deltaTime);

        rb.velocity = new Vector3(speed , rb.velocity.y);

        //TimeDelay();

        //bulletDropTime -= Time.deltaTime;
        //if(bulletDropTime <=0)
        //{
        //    //turn on gravity
        //    rb.useGravity = true;
        //}

        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            timeToDie = true;
        }

        if(timeToDie == true)
        {
            Destroy(gameObject);
            levelManagerScriptRef.bulletsInExistence.RemoveAt(0);
        }

       //if factory spawn exists do nto spawn another
       
    }



    //if hits player destroy
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.tag == "Ground")
        {
            spawnPoint.transform.position = gameObject.transform.position;

            if (levelManagerScriptRef.factoryInExistence.Count > 1)
            {
                //do not create factory
                //spawn particles for effect
                Destroy(gameObject);
                levelManagerScriptRef.RemoveExtraFactory();
              //  levelManagerScriptRef.bulletsInExistence.RemoveAt()
                
            }
            else if (levelManagerScriptRef.factoryInExistence.Count != 1) //if list = 0
            {
               // spawnPoint.transform.position = gameObject.transform.position; //change back if not work

                Instantiate(spawnFactory, spawnPoint.position, spawnPoint.rotation); //bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                Destroy(gameObject);
                //enemyAttackScriptRef.bulletsInExistence.RemoveAt(0);
                levelManagerScriptRef.bulletsInExistence.Clear();
                Debug.Log("Factroy is spawned");
                //enemyAttackScriptRef.bulletsInExistence.RemoveAt(0);

                //add factory object to list
                levelManagerScriptRef.factoryInExistence.Add(spawnFactory);
            }
        }

        if(other.tag == "Player")
        {
            //damage player
           
            Debug.Log("Hit player");

            Destroy(gameObject);
            //enemyAttackScriptRef.bulletsInExistence.RemoveAt(0);
            levelManagerScriptRef.bulletsInExistence.RemoveAt(0);
            //damage the player
        }
    }


}
