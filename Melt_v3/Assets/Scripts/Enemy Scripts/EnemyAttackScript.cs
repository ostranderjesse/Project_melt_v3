using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    //need a waitTimerToFire if player is hit

    #region spawnfactory notes for spawning
    /*
    if spawnFactory exists and a projectile is out and happens to hit the floor
    while a spawnfactory is active do not spawn a second factory unless the current
    one is destroyed
     
     */
    #endregion

    public Transform targetedPlayer;

    public Transform bulletSpawnPoint; //launchpoint

    public GameObject bulletPrefab; //projectile


    public List<GameObject> bulletsInExistence;

    public float launchVelocity = 10f;

    public int attackRange; //chaseRange
    public int attackIntervals = 5; //time between attacks

    public bool facingRight = true;

    //public BossProjectile bossProjectileRef;


    public bool canShoot = false;

    private void Start()
    {
       // bossProjectileRef = FindObjectOfType<BossProjectile>();

        targetedPlayer = GameObject.FindGameObjectWithTag("Player").transform;

        bulletsInExistence = new List<GameObject>();


        canShoot = false;

        facingRight = false;

     
    }


    private void Update()
    {
        float distance = Vector3.Distance(transform.position, targetedPlayer.transform.position);


       // killProjectile();


        if (distance <= attackRange && !canShoot) // canShoot = true
        {

            if (bulletsInExistence.Count >= 1)
            {
                canShoot = false;
               // bulletsInExistence.RemoveAt(0);// original code
                //bulletsInExistence.Clear(); // if doesnt work go back to original code
                
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
        yield return new WaitForSeconds(5f);
    }

    //public void killProjectile()
    //{

    //    if(bossProjectileRef == null)
    //    {
    //        bossProjectileRef = FindObjectOfType<BossProjectile>();
    //    }
    //    if (GameObject.FindGameObjectsWithTag("enemyProjectile").Length >= 1)
    //    {
    //        Debug.Log("Bullet count is >= than 1 destroy the rest");
    //        if(bossProjectileRef.lifeTime <= 0)
    //        {
    //            Debug.Log("projectile is destroyed remove it from the list");
    //            // bulletsInExistence.RemoveAt(0);
             
    //        }
            
          
    //    }
    //}

    public void Shooting()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        bulletsInExistence.Add(bulletPrefab);

    }
}
