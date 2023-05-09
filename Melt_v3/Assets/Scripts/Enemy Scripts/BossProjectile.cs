using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float lifeTime = 3f;

    public float timer;
  
    public GameObject spawnFactory;

    public Rigidbody rb;

    public EnemyAttackScript enemyAttackScriptRef;

    public Transform spawnPoint;

    public float speed;

   //private EnemyAttackScript enemyAttackScriptRef;


    public void Awake()
    {
   
    }
    // Start is called before the first frame update
    void Start()
    {
        

        rb = GetComponent<Rigidbody>();

        enemyAttackScriptRef = FindObjectOfType<EnemyAttackScript>();

        if(enemyAttackScriptRef.transform.localScale.x < 0 )
        {
            speed = -speed;
            Debug.Log("speed =" + speed);
        }

    }

    private void Update()
    {
        // rb.velocity = new Vector3(speed, Rigidbody.velocity.y);
       // rb.AddForce(Vector3.forward * speed * Time.deltaTime);

        rb.velocity = new Vector3(-speed , rb.velocity.y);

 
        Destroy(gameObject, lifeTime); //,lifetime

        if(gameObject == null)
        {
            enemyAttackScriptRef.bulletsInExistence.RemoveAt(0);
            enemyAttackScriptRef.canShoot = true;
            Debug.Log("Removed gameobject from existence. gameobject == null");
        }
        
       
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
            enemyAttackScriptRef.bulletsInExistence.RemoveAt(0);
        }

        if(other.tag == "Player")
        {
            //damage player
           
            Debug.Log("Hit player");

            Destroy(gameObject);
            enemyAttackScriptRef.bulletsInExistence.RemoveAt(0);
        }
    }


}
