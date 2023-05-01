using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{

    
    public Transform targetedPlayer;

    public Transform bulletSpawnPoint; //launchpoint
    public GameObject bulletPrefab; //projectile
    public float launchVelocity = 10f;

    public int attackRange; //chaseRange
    public int attackIntervals = 5; //time between attacks
    public int timer;

    private void Start()
    {
        targetedPlayer = GameObject.FindGameObjectWithTag("Player").transform;

        //attackIntervals = (int)Time.deltaTime;
       
    }


    private void Update()
    {
        float distance = Vector3.Distance(transform.position, targetedPlayer.transform.position);



        if(distance <= attackRange)
        {
            Debug.Log("Attack the Player now");
            //add timer to attacck
            //enemy should not attack this fast
            // Shooting();
            attackIntervals--;
            if(attackIntervals  <=0)
            {
                Debug.Log("interval hit 0 now shooting");
                Shooting();
                Debug.Log("shot made");
                Debug.Log("interval hit 0 resetting ");
                attackIntervals = 5;
                Debug.Log("interval now at 5");
            }
            else
            {
                Debug.Log("Do nothing but wait for next attack cycle");
           

            }
        }

    }

    public void Shooting()
    {
        var bulletProjectile = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity); // bulletSpawnPoint.rotation);

        bulletProjectile.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.up * launchVelocity;
    }
}
