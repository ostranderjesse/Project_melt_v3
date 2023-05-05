using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{

    
    public Transform targetedPlayer;

    public Transform bulletSpawnPoint; //launchpoint

    public GameObject bulletPrefab; //projectile
    //public Rigidbody bulletPrefabRB;

    //public List<GameObject> bulletInExistence = new List<GameObject>();

    public List<GameObject> bulletsInExistence;

    public float launchVelocity = 10f;

    public int attackRange; //chaseRange
    public int attackIntervals = 5; //time between attacks

  

    public bool canShoot = false;

    private void Start()
    {
        targetedPlayer = GameObject.FindGameObjectWithTag("Player").transform;

        bulletsInExistence = new List<GameObject>();

        //cache 
       // bulletPrefabRB = bulletPrefab.GetComponent<Rigidbody>();
        //bulletPrefab.GetComponent<Rigidbody>() = bulletPrefabRB;

       // bulletPrefabRB = bulletPrefab.;
        canShoot = false;
        
      
    }


    private void Update()
    {
        float distance = Vector3.Distance(transform.position, targetedPlayer.transform.position);



        if(distance <= attackRange && !canShoot) // canShoot = true
        {

            if(bulletsInExistence.Count > 1 )
            {
                canShoot = false;
                bulletsInExistence.RemoveAt(1);
            }
            else if ( bulletsInExistence.Count <=0)
            {
                Debug.Log("Attack the Player now");
                StartCoroutine(ShootProjectile());
            }


        }

    }

    IEnumerator ShootProjectile()
    {
        canShoot = true;
        Shooting();
        canShoot = false;
        yield return new WaitForSeconds(3f);
    }

    public void killProjectile()
    {
        if(GameObject.FindGameObjectsWithTag("enemyProjectile").Length > 1)
        {
            Debug.Log("Bullet count is > than 1 destroy the rest");
        }
    }

    public void Shooting()
    {
        //var bulletProjectile = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); // bulletSpawnPoint.rotation); Quaterninon.identity);
     var bullet =   Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        bulletsInExistence.Add(bulletPrefab);

        //move bullet forward
        //bulletPrefab.GetComponent<Rigidbody>().velocity = bulletPrefabRB.velocity;
        //bulletPrefab.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.up * launchVelocity;


        //bulletProjectile.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.up * launchVelocity;

        bullet.GetComponent<Rigidbody>().velocity = -bulletSpawnPoint.up * launchVelocity;
            
            
            //bulletPrefabRB.velocity = bulletSpawnPoint.up * launchVelocity; //.right
 

    }
}
