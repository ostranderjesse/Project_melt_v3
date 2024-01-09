using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDetection : MonoBehaviour
{
    public GameObject spawnFactory;

   // public Rigidbody rb;

    public Transform spawnPoint;

    public float lifeTime = 3f;

    [SerializeField]
    private EnemyAttackScript enemyAttackScriptRef; // take out code id not work right

    [SerializeField]
    private LevelManager levelManagerScriptRef;


    //testing variables area
    //lifeTime
    [SerializeField] private bool timeToDie = false;


    private void Start()
    {

       // spawnPoint.transform.position = gameObject.transform.position; // delete if not work

        enemyAttackScriptRef = FindObjectOfType<EnemyAttackScript>();

        if (enemyAttackScriptRef == null)
        {
            enemyAttackScriptRef = FindObjectOfType<EnemyAttackScript>();
        }

        levelManagerScriptRef = FindObjectOfType<LevelManager>();

        if (levelManagerScriptRef == null)
        {
            levelManagerScriptRef = FindObjectOfType<LevelManager>();
        }

       // rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            timeToDie = true;
        }

        if (timeToDie == true)
        {
            Destroy(gameObject);
            levelManagerScriptRef.bulletsInExistence.RemoveAt(0);
        }


        //if factory spawn exists do nto spawn another

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            //ector3 spawnPoint = transform.position;

            if (spawnPoint.transform.position == null) // new code delete if not work
            {
                spawnPoint.transform.position = gameObject.transform.position; // gameobject.transform.postion;
            }
            else
                spawnPoint.transform.position = gameObject.transform.position; // change back if not work




            Debug.Log("Hit ground");
           // spawnPoint.transform.position = gameObject.transform.position; // change back if not work

            if (levelManagerScriptRef.factoryInExistence.Count > 1)
            {
                //do not create factory
                //spawn particles for effect
                Destroy(gameObject);
                levelManagerScriptRef.RemoveExtraFactory();
                //  levelManagerScriptRef.bulletsInExistence.RemoveAt()

            }
            else if (levelManagerScriptRef.factoryInExistence.Count != 1) //if list = 0   // !=1 was the original.
            {
                if(spawnPoint.transform.position == null) // new code delete if not work
                {
                    spawnPoint.transform.position = gameObject.transform.position;
                }
                else
                spawnPoint.transform.position = gameObject.transform.position; // change back if not work

                //spawnPoint = gameObject.transform.position;

                Instantiate(spawnFactory, spawnPoint.position, spawnPoint.rotation); //bulletSpawnPoint.position, bulletSpawnPoint.rotation);

               // Instantiate(spawnFactory, spawnPoint)

                Destroy(gameObject);
                //enemyAttackScriptRef.bulletsInExistence.RemoveAt(0);
                levelManagerScriptRef.bulletsInExistence.Clear();
                Debug.Log("Factroy is spawned");
                //enemyAttackScriptRef.bulletsInExistence.RemoveAt(0);

                //add factory object to list
                levelManagerScriptRef.factoryInExistence.Add(spawnFactory);
            }
        }

        if (other.tag == "Player")
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